using System;
using UnityEngine;

namespace Base
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Spell = Animator.StringToHash("Spell");

        public Animator _animator { get; private set; }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void DoAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void DoSpell()
        {
            _animator.SetTrigger(Spell);
        }
    }
}