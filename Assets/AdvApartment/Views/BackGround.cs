using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
namespace MugitoDokumugi.AdvApart {
    public class BackGround : MonoBehaviour {
        public Subject<string> subject = new Subject<string>();
        [SerializeField] private RectTransform bgrect = null;
        [SerializeField] private RectTransform fuchirect = null;
        [SerializeField] private float rightmax = -105f;
        [SerializeField] private float leftmax = 100f;
        public void RightMove() {
            if(bgrect.position.x >= rightmax && fuchirect.position.x >= rightmax) {
                bgrect.position += new Vector3(-0.03f, 0, 0);
                fuchirect.position += new Vector3(-0.03f, 0, 0);
            }
            else {
                subject.OnNext("RightMax");
            }
        }
        public void LeftMove() {
            if(bgrect.position.x <= leftmax && fuchirect.position.x <= leftmax) {
                bgrect.position += new Vector3(0.03f, 0, 0);
                fuchirect.position += new Vector3(0.03f, 0, 0);
            }
            else {
                subject.OnNext("LeftMax");
            }
        }
    }
}