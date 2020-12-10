using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MugitoDokumugi.AdvOkujo {
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
        public int standlid { get; set; }
        public int standrid { get; set; }
        public void Set(int id) {
            Scenario scenario = Resources.Load<Scenario>("AdvOkujo/Scenarios/Scenario");
            this.id = scenario.data[id].id;
            this.characterid = scenario.data[id].characterid;
            this.charactername = scenario.data[id].charactername;
            this.text = scenario.data[id].text;
            this.standlid = scenario.data[id].standlid;
            this.standrid = scenario.data[id].standrid;
        }
        public int MaxId() {
            Scenario scenario = Resources.Load<Scenario>("AdvOkujo/Scenarios/Scenario");
            return scenario.data.Count;
        }
    }
}
