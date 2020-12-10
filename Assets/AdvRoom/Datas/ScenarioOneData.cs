namespace MugitoDokumugi.AdvRoom {
    [System.Serializable]
    public class ScenarioOneData {
        public int id = 0;
        public int characterid = 0;
        public string charactername = "";
        public string text = "";
        public ScenarioOneData(int id, int characterid, string charactername, string text) {
            this.id = id;
            this.characterid = characterid;
            this.charactername = charactername;
            this.text = text;
        }
        public int GetId() {
            return this.id;
        }
        public int GetCharacterId() {
            return this.characterid;
        }
        public string GetCharacterName() {
            return this.charactername;
        }
        public string GetText() {
            return this.text;
        }
        public void SetId(int id) {
            this.id = id;
        }
        public void SetCharacterId(int characterid) {
            this.characterid = characterid;
        }
        public void SetCharacterName(string charactername) {
            this.charactername = charactername;
        }
        public void SetText(string text) {
            this.text = text;
        }
    }
}