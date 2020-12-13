using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MugitoDokumugi.AdvRoom {
    public class MessageModel {
        // Singleton
        private static MessageModel instance;
        public static MessageModel Instance {
            get {
                if (instance == null) instance = new MessageModel();
                return instance;
            }
        }
        public int id { get; set; }
        public int characterid { get; set; }
        public string charactername { get; set; }
        public string text { get; set; }
        public void Set(int id) {
            ScenarioData scenario = Resources.Load<ScenarioData>("AdvRoom/Scenarios/Scenario");
            this.id = scenario.list[id].id;
            this.characterid = scenario.list[id].characterid;
            this.charactername = scenario.list[id].charactername;
            this.text = scenario.list[id].text;
        }
        public int GetMax() {
            ScenarioData scenario = Resources.Load<ScenarioData>("AdvRoom/Scenarios/Scenario");
            return scenario.list.Count - 1;
        }
    }
}
