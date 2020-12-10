using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MugitoDokumugi.AdvEnd {
    public class ScenarioModel {
        // Singleton
        private static ScenarioModel instance;
        public static ScenarioModel Instance {
            get {
                if (instance == null) instance = new ScenarioModel();
                return instance;
            }
        }
        public int id { get; set; }
        public int characterid { get; set; }
        public string charactername { get; set; }
        public string text { get; set; }
        public void Set(int id) {
            ScenarioData scenario = Resources.Load<ScenarioData>("AdvEnd/Scenarios/Scenario");
            this.id = scenario.paramater_list[id].id;
            this.characterid = scenario.paramater_list[id].characterid;
            this.charactername = scenario.paramater_list[id].charactername;
            this.text = scenario.paramater_list[id].text;
        }
        public int MaxId() {
            ScenarioData scenario = Resources.Load<ScenarioData>("AdvEnd/Scenarios/Scenario");
            return scenario.paramater_list.Count;
        }
    }
}
