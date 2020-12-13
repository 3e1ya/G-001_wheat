using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MugitoDokumugi.AdvRoom
{
    public class Pagebreak : MonoBehaviour {
        [SerializeField] private Animator animator = null;
        private void Start() {
            animator = this.gameObject.GetComponent<Animator>();
            animator.enabled = false;
        }
        public void Anime() {
            animator.Play("pagebreak");
            animator.enabled = true;
        }
        public void Stand() {
            animator.enabled = false;
        }
    }
}