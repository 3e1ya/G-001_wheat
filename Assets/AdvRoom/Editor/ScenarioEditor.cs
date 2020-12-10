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
namespace MugitoDokumugi.AdvRoom {
    [CustomEditor(typeof(ScenarioConfig))]
    public class ScenarioEditor : Editor {
        public override void OnInspectorGUI() {
            var config = target as ScenarioConfig;
            DrawDefaultInspector();
            if (GUILayout.Button("シナリオのロード")) {
                Load(config);
            }
        }
        public void Load(ScenarioConfig config) {
            if (config.excelfilepath == null) {
                Debug.LogError("variable is null");
                return;
            }
            //if (System.IO.File.Exists(config.excelfilepath)) {
            //    Debug.LogError("not excel file: " + config.excelfilepath);
            //    return;
            //}
            FileStream stream = new FileStream(config.excelfilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IWorkbook workbook = WorkbookFactory.Create(stream);
            ISheet sheet = workbook.GetSheet(config.sheetname);
            Debug.Log("sheet: " + sheet.SheetName);
            var scenario = CreateInstance<ScenarioData>();
            Debug.Log("scenario.data: " + scenario.list);
            for (int i = 1; i <= sheet.LastRowNum; i++) {
                int id = (int)sheet.GetRow(i).GetCell(0).NumericCellValue;
                int characterid = (int)sheet.GetRow(i).GetCell(1).NumericCellValue;
                string charactername = sheet.GetRow(i).GetCell(2).StringCellValue;
                string text = sheet.GetRow(i).GetCell(3).StringCellValue;
                Debug.Log("paramaters id: " + id + " characterid: " + characterid + " charactername: " + charactername + " text: " + text);
                scenario.list.Add(new ScenarioOneData(id, characterid, charactername, text));
                Debug.Log((int)sheet.GetRow(i).GetCell(0).NumericCellValue);
            }
            var asset = (ScenarioData)AssetDatabase.LoadAssetAtPath(config.outputfilepath, typeof(ScenarioData));
            if (asset == null) {
                AssetDatabase.CreateAsset(scenario, config.outputfilepath);
            }
            else {
                EditorUtility.CopySerialized(scenario, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();
            workbook.Close();
        }
    }
}