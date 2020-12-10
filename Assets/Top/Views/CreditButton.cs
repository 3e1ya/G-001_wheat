using UnityEngine;
using UniRx;
namespace MugitoDokumugi.Top {
    public class CreditButton : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick() {
            subject.OnNext(Unit.Default);
        }
    }
}