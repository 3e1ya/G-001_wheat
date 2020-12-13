using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using MugitoDokumugi.Common;
namespace MugitoDokumugi.AdvOkujo
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Character character = null;
        [SerializeField] private CharacterName charactername = null;
        [SerializeField] private Pagebreak pagebreak = null;
        [SerializeField] private Sentence sentence = null;
        [SerializeField] private NextButton nextbutton = null;
        [SerializeField] private int id = 1;
        [SerializeField] private int maxid;
        void Start()
        {
            maxid = ScenarioModel.Instance.MaxId();
            NextParamater();
            nextbutton.subject
                .Subscribe(x => NextParamater());
            SoundController.Instance.PlayBgm(3);
        }
        void Update()
        {
            if (sentence.rendering)
            {
                pagebreak.Stand();
            }
            else if(!sentence.rendering)
            {
                pagebreak.Anime();
            }
        }
        void NextParamater()
        {
            if (id < maxid)
            {
                pagebreak.Stand();
                ScenarioModel.Instance.Set(id);
                id++;
                charactername.Render();
                character.Render();
                sentence.Render(0.07f);
            }
            else
            {
                SceneManager.LoadScene("AdvEnd");
            }
        }
    }
}