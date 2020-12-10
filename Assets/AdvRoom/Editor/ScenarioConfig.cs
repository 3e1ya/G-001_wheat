using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace MugitoDokumugi.AdvRoom {
    [CreateAssetMenu(menuName = "Editor/ScenarioConfig/AdvRoom", fileName = "ScenarioConfig")]
    public class ScenarioConfig : ScriptableObject {
        public string excelfilepath;
        public string sheetname;
        public string outputfilepath;
        void OnEnable() {
            excelfilepath = Application.dataPath + @"\Resources\AdvRoom\Scenarios\Scenario.xlsx";
            sheetname = "１自室";
            outputfilepath = @"Assets/Resources/AdvRoom/Scenarios/Scenario.asset";
        }
    }
}