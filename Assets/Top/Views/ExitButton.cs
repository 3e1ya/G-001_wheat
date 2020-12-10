using UnityEngine;
using UniRx;
namespace MugitoDokumugi.Top
{
    public class ExitButton : MonoBehaviour
    {
        public Subject<Unit> subject = new Subject<Unit>();
        public void OnClick()
        {
            Debug.Log("ss");
            subject.OnNext(Unit.Default);
        }
        private void OnStart()
        {

        }
        private void OnUpdate()
        {

        }
        private void Start() => OnStart();
        private void Update() => OnUpdate();
    }
}