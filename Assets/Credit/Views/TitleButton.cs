using UnityEngine;
using UniRx;
namespace MugitoDokumugi.Credit {
    public class TitleButton : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick() {
            subject.OnNext(Unit.Default);
        }
    }
}