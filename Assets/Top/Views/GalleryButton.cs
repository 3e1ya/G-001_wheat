using UnityEngine;
using UniRx;
namespace MugitoDokumugi.Top {
    public class GalleryButton : MonoBehaviour {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick() {
            SoundController.PlaySe("1");
            subject.OnNext(Unit.Default);
        }
    }
}
