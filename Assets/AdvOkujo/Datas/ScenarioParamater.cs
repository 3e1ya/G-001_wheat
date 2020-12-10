namespace MugitoDokumugi.AdvOkujo {
    [System.Serializable]
    public class ScenarioParamater {
        public int id;
        public int characterid;
        public string charactername;
        public string text;
        public int standlid;
        public int standrid;
        public ScenarioParamater(int id, int characterid, string charactername, string text, int standlid, int standrid) {
            this.id = id;
            this.characterid = characterid;
            this.charactername = charactername;
            this.text = text;
            this.standlid = standlid;
            this.standrid = standrid;
        }
    }
}