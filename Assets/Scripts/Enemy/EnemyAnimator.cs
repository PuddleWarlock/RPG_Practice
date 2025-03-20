using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Death = Animator.StringToHash("Death");
        
        public Animator _animator { get; private set; }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void DeathEvent()
        {
            _animator.SetTrigger(Death);
        }
        
        
    }
}