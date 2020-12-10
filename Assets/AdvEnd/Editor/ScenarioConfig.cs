using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace MugitoDokumugi.AdvEnd {
    [CreateAssetMenu(menuName = "Editor/ScenarioConfig/AdvEnd", fileName = "ScenarioConfig")]
    public class ScenarioConfig : ScriptableObject {
        public string excelpath;
        public string sheetname;
        public string outputpath;
        void OnEnable() {
            excelpath = Application.dataPath + @"\Resources\AdvEnd\Scenarios\Scenario.xlsx";
            sheetname = "３エンド";
            outputpath = @"Assets/Resources/AdvEnd/Scenarios/Scenario.asset";
        }
    }
}