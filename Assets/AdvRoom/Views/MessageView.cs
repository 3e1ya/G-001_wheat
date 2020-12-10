using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace MugitoDokumugi.AdvRoom {
    public class MessageView : MonoBehaviour {
        public Text charactername;
        public Text text;
        public Sprite next;
        public void RenderText() {
            this.charactername.text = MessageModel.Instance.charactername;
            this.text.text = MessageModel.Instance.text;
        }
        public void RenderText(int speed) {
            this.charactername.text = MessageModel.Instance.charactername;
            this.text.DOPause();
            this.text.text = "";
            this.text.DOText(MessageModel.Instance.text, speed).SetEase(Ease.Linear);
        }
    }
}