using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace MugitoDokumugi.AdvOkujo {
    public class Sentence : MonoBehaviour {
        Text text;
        private void Start() {
            text = this.gameObject.GetComponent<Text>();
        }
        public void Render(float speed) {
            text.DOPause();
            text.text = "";
            text.DOText(ScenarioModel.Instance.text, speed).SetEase(Ease.Linear);
        }
    }
}