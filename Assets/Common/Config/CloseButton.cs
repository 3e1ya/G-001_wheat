using System.Collections;
using UnityEngine;
using UniRx;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.Common
{
    public class CloseButton : MonoBehaviour
    {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick()
        {
            subject.OnNext(Unit.Default);
            SoundController.Instance.PlaySe(1);
        }
    }
}