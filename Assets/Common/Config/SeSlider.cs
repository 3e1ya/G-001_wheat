using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.Common
{
    public class SeSlider : MonoBehaviour
    {
        Slider slider;
        void Start()
        {
            slider = GetComponent<Slider>();
            slider.value = SoundController.Instance.volume.se;
        }
        void Update()
        {
            SoundController.Instance.volume.se = slider.value;
        }
    }
}