using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
namespace MugitoDokumugi.AdvEnd {
    [CustomEditor(typeof(ScenarioConfig))]
    public class ScenarioConverter : Editor {
        public override void OnInspectorGUI() {
            var config = target as ScenarioConfig;
            DrawDefaultInspector();
            if (GUILayout.Button("Convert")) {
                Execute(config);
            }
        }
        public void Execute(ScenarioConfig config) {
            if (config.excelpath == null) {
                Debug.LogError("variable is null");
                return;
            }
            FileStream stream = new FileStream(config.excelpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IWorkbook workbook = WorkbookFactory.Create(stream);
            ISheet sheet = workbook.GetSheet(config.sheetname);
            var scenariodata = CreateInstance<ScenarioData>();
            for (int i = 1; i <= sheet.LastRowNum; i++) {
                int id = (int)sheet.GetRow(i).GetCell(0).NumericCellValue;
                int characterid = (int)sheet.GetRow(i).GetCell(1).NumericCellValue;
                string charactername = sheet.GetRow(i).GetCell(2).StringCellValue;
                string text = sheet.GetRow(i).GetCell(3).StringCellValue;
                scenariodata.paramater_list.Add(new ScenarioParamater(id, characterid, charactername, text));
            }
            var asset = (ScenarioData)AssetDatabase.LoadAssetAtPath(config.outputpath, typeof(ScenarioData));
            if (asset == null) {
                AssetDatabase.CreateAsset(scenariodata, config.outputpath);
            }
            else {
                EditorUtility.CopySerialized(scenariodata, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();
            workbook.Close();
        }
    }
}