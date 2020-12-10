using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi
{
    public class BgmSlider : MonoBehaviour
    {
        Slider slider;
        private void OnStart()
        {
            SoundController.LoadBgm("1", "Bgm/1_future_start");
            SoundController.PlayBgm("1");
            slider = GetComponent<Slider>();
            slider.value = 1f;
        }
        private void OnUpdate()
        {
            GameParamater.bgmvolume = slider.value;
        }
        private void Start() => OnStart();
        private void Update() => OnUpdate();
    }
}