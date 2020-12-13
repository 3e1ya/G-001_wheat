using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvRoom
{
    public class CharacterName : MonoBehaviour {
        private Text text;
        private void Awake() {
            text = this.gameObject.GetComponent<Text>();
        }
        public void Render() {
            text.text = MessageModel.Instance.charactername;
        }
    }
}
