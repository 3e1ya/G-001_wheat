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
namespace MugitoDokumugi.AdvOkujo {
    [CustomEditor(typeof(ScenarioConfig))]
    public class ScenarioConverter : Editor {
        public override void OnInspectorGUI() {
            var config = target as ScenarioConfig;
            DrawDefaultInspector();
            if (GUILayout.Button("シナリオのロード")) {
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
            Debug.Log("sheet: " + sheet.SheetName);
            var scenario = CreateInstance<Scenario>();
            Debug.Log("scenario.data: " + scenario.data);
            for (int i = 1; i <= sheet.LastRowNum; i++) {
                int id = (int)sheet.GetRow(i).GetCell(0).NumericCellValue;
                int characterid = (int)sheet.GetRow(i).GetCell(1).NumericCellValue;
                string charactername = sheet.GetRow(i).GetCell(2).StringCellValue;
                string text = sheet.GetRow(i).GetCell(3).StringCellValue;
                int standlid = (int)sheet.GetRow(i).GetCell(4).NumericCellValue;
                int standrid = (int)sheet.GetRow(i).GetCell(6).NumericCellValue;
                //Debug.Log("paramaters id: " + id + " characterid: " + characterid + " charactername: " + charactername + " text: " + text);
                scenario.data.Add(new ScenarioParamater(id, characterid, charactername, text, standlid, standrid));
                Debug.Log((int)sheet.GetRow(i).GetCell(0).NumericCellValue);
            }
            var asset = (Scenario)AssetDatabase.LoadAssetAtPath(config.outputpath, typeof(Scenario));
            if (asset == null) {
                AssetDatabase.CreateAsset(scenario, config.outputpath);
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