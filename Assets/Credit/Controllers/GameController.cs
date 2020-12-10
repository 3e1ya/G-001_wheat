using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.Credit {
    public class GameController : MonoBehaviour {
        [SerializeField] private TitleButton titlebutton = null;
        private void Start() {
            titlebutton.subject
                .Subscribe(x => TopScene());
        }
        private void TopScene() {
            SceneManager.LoadScene("Top");
        }
    }
}
