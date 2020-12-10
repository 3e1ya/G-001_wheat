using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "ScriptableObject/AdvTextData")]
public class AdvTextData : ScriptableObject {
    public List<AdvTextModel> list = new List<AdvTextModel>();
}