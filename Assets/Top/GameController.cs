using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using MugitoDokumugi.Common;
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
            SoundController.Instance.PlayBgm(0);
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

    }
}
