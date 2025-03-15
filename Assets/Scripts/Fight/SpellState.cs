using Base;
using Move;
using UnityEngine;

namespace Fight
{
    public class SpellState : BasePlayerState
    {
        private CooldownSystem _cooldownSystem;
        private GameObject _sword;
        public SpellState(MovementController movementController, CooldownSystem cooldownSystem) : base(movementController)
        {
            _cooldownSystem = cooldownSystem;
        }

        public override void Enter()
        { 
            Debug.Log("Entering Spell");
            MovementController._playerAnimator.DoSpell();
            _cooldownSystem.SpellReady = false;
            _sword = GameObject.Find("Sword");
            _sword.SetActive(false);

        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            _sword.SetActive(true);
            Debug.Log("Exiting Spell");
        }
    }
}