using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
namespace MugitoDokumugi.AdvEnd {
    public class NextButton : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick() {
            subject.OnNext(Unit.Default);
        }
    }
}