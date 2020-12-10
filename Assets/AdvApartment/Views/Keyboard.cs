using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace MugitoDokumugi.AdvApart {
    public class Keyboard : MonoBehaviour {
        public Subject<string> subject = new Subject<string>();
        void Update() {
            if (Input.GetKey(KeyCode.A)) {
                subject.OnNext("A");
            }
            else if (Input.GetKey(KeyCode.D)) {
                subject.OnNext("D");
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
                subject.OnNext("Release");
            }
        }
    }
}