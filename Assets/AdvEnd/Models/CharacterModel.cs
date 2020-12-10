using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvEnd {
    public class CharacterModel {
        // Singleton
        private static CharacterModel instance;
        public static CharacterModel Instance {
            get {
                if (instance == null) instance = new CharacterModel();
                return instance;
            }
        }
        public Image image = null;
        public void Set(int characterid) {
            image = Resources.Load<Image>("Common/Character/" + characterid);
        }
    }
}