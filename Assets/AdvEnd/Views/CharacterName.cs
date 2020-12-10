using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvEnd {
    public class CharacterName : MonoBehaviour {
        private Text text;
        private void Start() {
            text = this.gameObject.GetComponent<Text>();
        }
        public void Render() {
            text.text = ScenarioModel.Instance.charactername;
        }
    }
}
