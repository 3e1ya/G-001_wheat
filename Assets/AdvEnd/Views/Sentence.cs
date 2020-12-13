using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
namespace MugitoDokumugi.AdvEnd {
    public class Sentence : MonoBehaviour {
        Text text;
        public bool rendering;
        void Awake()
        {
            text = this.gameObject.GetComponent<Text>();
        }
        void FixedUpdate()
        {
            if (DOTween.IsTweening(text))
            {
                rendering = true;
            }
            else
            {
                rendering = false;
            }
        }
        public void Render(float speed)
        {
            text.DOKill();
            text.text = "";
            text.DOText(ScenarioModel.Instance.text, ScenarioModel.Instance.text.Length * speed);
        }
    }
}