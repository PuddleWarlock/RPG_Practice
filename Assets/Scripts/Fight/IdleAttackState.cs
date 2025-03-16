using Base;
using Move;
using StateMachines;
using UnityEngine;

namespace Fight
{
    public class IdleAttackState : FightPlayerState
    {
        public IdleAttackState(FightController fightController, CooldownSystem cooldownSystem, PlayerAnimator animator) : base(fightController, cooldownSystem, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering IdleAttack");
        }

        public override void Execute( )
        {
        }

        public override void Exit( )
        {
            Debug.Log("Exiting IdleAttack");
        }
    }
}