using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.AdvOkujo {
    public class GameController : MonoBehaviour {
        [SerializeField] private Character character = null;
        [SerializeField] private CharacterName charactername = null;
        [SerializeField] private Pagebreak pagebreak = null;
        [SerializeField] private Sentence sentence = null;
        [SerializeField] private NextButton nextbutton = null;
        [SerializeField] private int id = 0;
        [SerializeField] private int maxid;
        public void Start() {
            maxid = ScenarioModel.Instance.MaxId();
            nextbutton.subject
                .Subscribe(x => NextParamater());
            
        }
        private void NextParamater() {
            if (id < maxid) {
                pagebreak.Stand();
                ScenarioModel.Instance.Set(id);
                id++;
                charactername.Render();
                character.Render();
                sentence.Render(0.1f);
            }
            else {
                SceneManager.LoadScene("AdvApart");
            }
        }
    }
}