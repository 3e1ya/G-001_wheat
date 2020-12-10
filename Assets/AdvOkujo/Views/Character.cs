using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvOkujo {
    public class Character : MonoBehaviour {
        private Image image = null;
        private void Start() {
            image = this.gameObject.GetComponent<Image>();
        }
        public void Render() {
            image = CharacterModel.Instance.image;
        }
    }
}