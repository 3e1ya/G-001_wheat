using UnityEngine;
using UniRx;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.Common
{
    public class ConfigButton : MonoBehaviour
    {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick()
        {
            Debug.Log("OnClick");
            subject.OnNext(Unit.Default);
            SoundController.Instance.PlaySe(1);
        }
    }
}