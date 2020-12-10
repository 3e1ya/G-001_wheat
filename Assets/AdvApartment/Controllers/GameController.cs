using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.AdvApart {
    public class GameController : MonoBehaviour {
        [SerializeField] private Keyboard keyboard = null;
        [SerializeField] private RyoIchinomiya ryoichinomiya = null;
        [SerializeField] private BackGround background = null;
        private void Start() {
            keyboard.subject
                .Subscribe(message => RyoIchinomiya(message));
            background.subject
                .Subscribe(message => BackGround(message));
        }
        private void RyoIchinomiya(string message) {
            if (message == "A") {
                ryoichinomiya.LeftWalk();
                background.LeftMove();
            }
            else if (message == "D") {
                ryoichinomiya.RightWalk();
                background.RightMove();
            }
            else if (message == "Release") {
                ryoichinomiya.Stand();
            }
        }
        private void BackGround(string message) {
            if (message == "RightMax") {
                // 主人公がエレベータにのるイベント
            }
            else if (message == "LeftMax") {
                ryoichinomiya.RightWalk();
                // 右のエレベーターにのることを、プレイヤーに知らせるイベント
            }
        }
    }
}