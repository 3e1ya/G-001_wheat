using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.AdvRoom {
    public class GameController : MonoBehaviour {
        [SerializeField] private WindowView windowview = null;
        [SerializeField] private MessageView messageview = null;
        [SerializeField] private int id = 0;
        [SerializeField] private int maxid;
        public void Start() {
            //最大頁数を取得
            maxid = MessageModel.Instance.GetMax();
            //ウィンドウを監視してクリックされたら次の頁を表示
            windowview.subject
                .Subscribe(x => Message());
        }
        public void Message() {
            if (id < maxid) {
                MessageModel.Instance.Set(id);
                id++;
                messageview.RenderText(1);
            }
            else {
                SceneManager.LoadScene("AdvApart");
            }
        }
    }
}
