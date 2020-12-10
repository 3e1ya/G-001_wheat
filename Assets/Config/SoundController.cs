using System.Collections;
using UnityEngine;
namespace MugitoDokumugi.Config
{
    [System.Serializable]
    public class SoundVolume
    {
        public float bgm = 1.0f;
        public float se = 1.0f;

        public bool mute = false;

        public void Reset()
        {
            bgm = 1.0f;
            se = 1.0f;
            mute = false;
        }
    }
    public class SoundController : SingletonMonoBehaviour<SoundController>
    {

        private void OnStart()
        {

        }
        private void OnUpdate()
        {

        }
        private void Start() => OnStart();
        private void Update() => OnUpdate();
    }
}