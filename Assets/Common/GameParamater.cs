using System.Collections;
using UnityEngine;
namespace MugitoDokumugi
{
    public class GameParamater : MonoBehaviour
    {        
        [SerializeField, Range(0, 1)] public static float bgmvolume = 1.0f;
        [SerializeField, Range(0, 1)] public static float sevolume = 1.0f;
        private void OnStart()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
        private void OnUpdate()
        {

        }
        private void Start() => OnStart();
        private void Update() => OnUpdate();
    }
}