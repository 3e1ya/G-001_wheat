using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.AdvRoom {
    public class GameController : MonoBehaviour {
        [SerializeField] private CharacterName charactername = null;
        [SerializeField] private Sentence sentence = null;
        [SerializeField] private Pagebreak pagebreak = null;
        [SerializeField] private NextButton nextbutton = null;
        [SerializeField] private int id = 0;
        [SerializeField] private int maxid;
        void Start() {
            //最大頁数を取得
            maxid = MessageModel.Instance.GetMax();
            //初ページ表示
            NextParamater();
            //ウィンドウを監視してクリックされたら次の頁を表示
            nextbutton.subject
                .Subscribe(x => NextParamater());
            SoundController.Instance.PlayBgm(1);
        }
        void Update()
        {
            if (sentence.rendering)
            {
                pagebreak.Stand();
            }
            else if (!sentence.rendering)
            {
                pagebreak.Anime();
            }
        }
        void NextParamater() {
            if (id < maxid)
            {
                pagebreak.Stand();
                MessageModel.Instance.Set(id);
                id++;
                charactername.Render();
                sentence.Render(0.1f);
            }
            else
            {
                SceneManager.LoadScene("AdvApartment");
            }
        }
    }
}
