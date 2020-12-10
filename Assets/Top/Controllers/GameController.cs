using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.Top
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private StartButton startbutton = null;
        [SerializeField] private GalleryButton gallerybutton = null;
        [SerializeField] private ExitButton exitbutton = null;
        private void Start() => OnStart();
        private void OnStart()
        {
            SoundSet();
            startbutton.subject
                .Subscribe(x => AdvScene());
            gallerybutton.subject
                .Subscribe(x => GalleryScene());
            exitbutton.subject
                .Subscribe(x => Exit());
        }
        private void GalleryScene()
        {
            SceneManager.LoadScene("Gallery");
        }
        private void AdvScene()
        {
            SceneManager.LoadScene("AdvRoom");
        }
        private void Exit()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
	    	Application.Quit();
        #endif
        }
        private void SoundSet()
        {
            SoundController.LoadBgm("1", "Bgm/1_future_start");
            SoundController.LoadBgm("2", "Bgm/2_wheat_room");
            SoundController.LoadBgm("3", "Bgm/3_arrival_flag");
            SoundController.LoadBgm("4", "Bgm/4_kill_myself");
            SoundController.LoadBgm("5", "Bgm/5_wheat_partner");
            SoundController.LoadSe("1", "Se/1_buttonclick");
            SoundController.LoadSe("2", "Se/2_titleclick");
            SoundController.PlayBgm("1");
        }
    }
}
