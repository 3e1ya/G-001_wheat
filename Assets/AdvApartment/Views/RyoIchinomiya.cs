using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace MugitoDokumugi.AdvApart {
    public class RyoIchinomiya : MonoBehaviour {
        [SerializeField] private Animator animator = null;
        public void Stand() {
            animator.enabled = false;
        }
        public void RightWalk() {
            animator.enabled = false;
            animator.Play("RightWalk");
            animator.enabled = true;
        }
        public void LeftWalk() {
            animator.enabled = false;
            animator.Play("LeftWalk");
            animator.enabled = true;
        }
    }
}