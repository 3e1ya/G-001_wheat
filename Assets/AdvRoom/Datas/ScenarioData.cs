using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvRoom {
    [CreateAssetMenu(menuName = "ScriptableObject/ScenarioData")]
    public class ScenarioData : ScriptableObject {
        public List<ScenarioOneData> list = new List<ScenarioOneData>();
    }
}