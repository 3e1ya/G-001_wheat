using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
namespace MugitoDokumugi.AdvRoom {
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
            text.DOText(MessageModel.Instance.text, MessageModel.Instance.text.Length * speed);
        }
    }
}