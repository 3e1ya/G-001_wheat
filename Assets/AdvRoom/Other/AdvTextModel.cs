[System.Serializable]
public class AdvTextModel {
    public int Id = 0;
    public int CharaId = 1;
    public string CharaName = "社会人";
    public string Text = "今日も定時退社決めました。";
    public int GetId() {
        return this.Id;
    }
    public int GetCharaId() {
        return this.CharaId;
    }
    public string GetCharaName() {
        return this.CharaName;
    }
    public string GetText() {
        return this.Text;
    }
    public void SetId(int Id)
    {
        this.Id = Id;
    }
    public void SetCharaId(int CharaId)
    {
        this.CharaId = CharaId;
    }
    public void SetCharaName(string CharaName)
    {
        this.CharaName = CharaName;
    }
    public void SetText(string Text)
    {
        this.Text = Text;
    }
}
