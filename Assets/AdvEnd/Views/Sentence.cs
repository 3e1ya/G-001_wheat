using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
namespace MugitoDokumugi.AdvEnd {
    public class Sentence : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        private Text text = null;
        private void Start() {
            text = this.gameObject.GetComponent<Text>();
        }
        public void Render(float speed) {
            text.DOPause();
            text.text = "";
            text.DOText(ScenarioModel.Instance.text, ScenarioModel.Instance.text.Length * speed);
        }
    }
}