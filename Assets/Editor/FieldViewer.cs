using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace MugitoDokumugi
{
    public class FieldViewer : EditorWindow
    {

        [SerializeField]
        private List<KeyValuePair<string, string>> _jsons = new List<KeyValuePair<string, string>>();

        [MenuItem("Window/Field Viewer")]
        private static void Open()
        {
            GetWindow<FieldViewer>("Field Viewer");
        }

        private void SetTarget(System.Object[] objs)
        {
            _jsons.Clear();
            foreach (var obj in objs)
            {
                _jsons.Add(new KeyValuePair<string, string>(obj.GetType().Name, JsonUtility.ToJson(obj, true)));
            }
        }

        private void OnGUI()
        {
            var multiRowLabelStyle = new GUIStyle(GUI.skin.label);
            multiRowLabelStyle.wordWrap = true;

            foreach (var json in _jsons)
            {
                // クラス名
                EditorGUILayout.LabelField(json.Key, EditorStyles.boldLabel);

                // オブジェクトの変数をjsonで表示
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField(json.Value, multiRowLabelStyle);
                EditorGUILayout.EndVertical();
            }
        }

        private void OnSelectionChange()
        {
            // 使い方の例
            if (Selection.activeGameObject == null)
            {
                return;
            }
            var targets = Selection.activeGameObject.GetComponents<MonoBehaviour>();
            SetTarget(targets);
            Repaint();
        }
    }
}