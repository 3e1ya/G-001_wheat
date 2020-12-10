using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvOkujo {
    public class CharacterName : MonoBehaviour {
        Text text;
        private void Start() {
            text = this.gameObject.GetComponent<Text>();
        }
        public void Render() {
            text.text = ScenarioModel.Instance.charactername;
        }
    }
}
