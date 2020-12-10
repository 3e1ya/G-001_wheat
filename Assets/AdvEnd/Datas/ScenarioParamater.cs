namespace MugitoDokumugi.AdvEnd {
    [System.Serializable]
    public class ScenarioParamater {
        public int id;
        public int characterid;
        public string charactername;
        public string text;
        public ScenarioParamater(int id, int characterid, string charactername, string text) {
            this.id = id;
            this.characterid = characterid;
            this.charactername = charactername;
            this.text = text;
        }
    }
}