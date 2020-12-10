using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class AdvTextView : MonoBehaviour {
    [SerializeField] public Text charaname;
    [SerializeField] public Text text;
    [SerializeField] public AdvTextData advtextdata;
    public void LoadText(int id) {
        text.text = advtextdata.list[id].GetText();
    }
    public void LoadCharaName(int id) {
        charaname.text = advtextdata.list[id].GetCharaName();
    }
    public IEnumerator Anime() {
        Debug.Log("enumrator: null");
        yield return null ;
    }
    public void Start() {
        //text.text = "";
        //text.DOText("あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめも", 3)
            //.SetEase(Ease.Linear);
    }
//    public void View(AdvTextModel advText) {
        //texta.text = advText.GetTextA();
//    }
    //IEnumerator Anime(){
    //}
}
