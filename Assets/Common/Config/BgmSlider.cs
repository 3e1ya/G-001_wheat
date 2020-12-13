using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.Common
{
    public class BgmSlider : MonoBehaviour
    {
        Slider slider;
        void Start()
        {
            slider = GetComponent<Slider>();
            slider.value = SoundController.Instance.volume.bgm;
        }
        void Update()
        {
            SoundController.Instance.volume.bgm = slider.value;
        }
    }
}