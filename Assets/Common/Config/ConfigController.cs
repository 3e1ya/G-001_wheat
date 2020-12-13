using System.Collections;
using UnityEngine;
using UniRx;
namespace MugitoDokumugi.Common
{
    public class ConfigController : MonoBehaviour
    {
        [SerializeField] ConfigButton configbutton = null;
        [SerializeField] CloseButton closebutton = null;
        [SerializeField] GameObject mask = null;
        [SerializeField] GameObject config = null;
        void Start()
        {
            mask.SetActive(false);
            config.SetActive(false);
            configbutton.subject
                .Subscribe(x => Config());
            closebutton.subject
                .Subscribe(x => Close());
        }
        void Config()
        {
            mask.SetActive(true);
            config.SetActive(true);
        }
        void Close()
        {
            mask.SetActive(false);
            config.SetActive(false);
        }
    }
}