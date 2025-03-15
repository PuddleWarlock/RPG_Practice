using Base;
using Move;
using UnityEngine;

namespace Fight
{
    public class AttackState : BasePlayerState
    {
        private CooldownSystem _cooldownSystem;
        private Collider _sword;
        public AttackState(PlayerController playerController, CooldownSystem cooldownSystem) : base(playerController)
        {
            _cooldownSystem = cooldownSystem;
            _sword = GameObject.Find("Sword").GetComponent<BoxCollider>();
        }

        public override void Enter()
        {
            _sword.enabled = true;
            Debug.Log("Entering Melee");
            PlayerController._playerAnimator.DoAttack();
            _cooldownSystem.MeleeReady = false;

        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            _sword.enabled = false;
            Debug.Log("Exiting Melee");
        }
    }
}