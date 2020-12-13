using UnityEngine;
using UnityEngine.SceneManagement;
namespace MugitoDokumugi.PreLoad
{
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene("Top");
        }
    }
}