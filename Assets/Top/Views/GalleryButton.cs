using UnityEngine;
using UniRx;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.Top {
    public class GalleryButton : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick() {
            subject.OnNext(Unit.Default);
            SoundController.Instance.PlaySe(1);
        }
    }
}
