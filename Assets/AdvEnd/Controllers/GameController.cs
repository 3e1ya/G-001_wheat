using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.AdvEnd {
    public class GameController : MonoBehaviour {
        [SerializeField] private CharacterName charactername = null;
        [SerializeField] private Sentence sentence = null;
        [SerializeField] private Pagebreak pagebreak = null;
        [SerializeField] private NextButton nextbutton = null;
        [SerializeField] private int id;
        private void Initialize() {
            charactername = GameObject.Find("/Views/CharacterName").GetComponent<CharacterName>();
            sentence = GameObject.Find("/Views/Sentence").GetComponent<Sentence>();
            pagebreak = GameObject.Find("/Views/PageBreak").GetComponent<Pagebreak>();
            nextbutton = GameObject.Find("/Views/NextButton").GetComponent<NextButton>();
        }
        private void Start() {
            Initialize();
            nextbutton.subject
                .Subscribe(x => NextParamater());
        }
        private void NextParamater() {
            Debug.Log("Next");
            if (id < ScenarioModel.Instance.MaxId()) {
                ScenarioModel.Instance.Set(id);
                id++;
                charactername.Render();
                sentence.Render(1.0f);
            }
            else {
                SceneManager.LoadScene("AdvApart");
            }
        }
    }
}