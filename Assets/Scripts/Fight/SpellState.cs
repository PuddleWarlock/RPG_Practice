using Base;
using Move;
using UnityEngine;

namespace Fight
{
    public class SpellState : BasePlayerState
    {
        private CooldownSystem _cooldownSystem;
        private GameObject _sword;
        public SpellState(PlayerController playerController, CooldownSystem cooldownSystem) : base(playerController)
        {
            _cooldownSystem = cooldownSystem;
        }

        public override void Enter()
        { 
            Debug.Log("Entering Spell");
            PlayerController._playerAnimator.DoSpell();
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