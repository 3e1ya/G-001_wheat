using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace MugitoDokumugi.AdvOkujo {
    [CreateAssetMenu(menuName = "Editor/ScenarioConfig/AdvOkujo", fileName = "ScenarioConfig")]
    public class ScenarioConfig : ScriptableObject {
        public string excelpath;
        public string sheetname;
        public string outputpath;
        void OnEnable() {
            excelpath = Application.dataPath + @"\Resources\AdvOkujo\Scenarios\Scenario.xlsx";
            sheetname = "２屋上";
            outputpath = @"Assets/Resources/AdvOkujo/Scenarios/Scenario.asset";
        }
    }
}