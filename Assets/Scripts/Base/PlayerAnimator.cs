using System;
using UnityEngine;

namespace Base
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Spell = Animator.StringToHash("Spell");
        
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");

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
        
        public void DoJump()
        {
            _animator.SetTrigger(Jump);
        }
        
        public void DoWalk()
        {   
            _animator.SetBool(Run, false);
            _animator.SetBool(Walk, true);
        }
        
        
        public void DoRun() 
        {
            _animator.SetBool(Walk, false);
            _animator.SetBool(Run, true);
        }
        
        public void DoIdleMove() 
        {
            _animator.SetBool(Walk, false);
            _animator.SetBool(Run, false);
        }
        
    }
}