using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.AdvEnd
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private CharacterName charactername = null;
        [SerializeField] private Sentence sentence = null;
        [SerializeField] private Pagebreak pagebreak = null;
        [SerializeField] private NextButton nextbutton = null;
        [SerializeField] private int id;
        void Initialize()
        {
            charactername = GameObject.Find("/Views/CharacterName").GetComponent<CharacterName>();
            sentence = GameObject.Find("/Views/Sentence").GetComponent<Sentence>();
            pagebreak = GameObject.Find("/Views/PageBreak").GetComponent<Pagebreak>();
            nextbutton = GameObject.Find("/Views/NextButton").GetComponent<NextButton>();
        }
        void Start()
        {
            Initialize();
            NextParamater();
            nextbutton.subject
                .Subscribe(x => NextParamater());
            SoundController.Instance.PlayBgm(4);
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
        void NextParamater()
        {
            if (id < ScenarioModel.Instance.MaxId())
            {
                pagebreak.Stand();
                ScenarioModel.Instance.Set(id);
                id++;
                charactername.Render();
                sentence.Render(0.1f);
            }
            else
            {
                SceneManager.LoadScene("Top");
            }
        }
    }
}