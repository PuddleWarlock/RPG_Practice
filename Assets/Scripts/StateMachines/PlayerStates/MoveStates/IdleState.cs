using Anims;
using Controllers.Entities;
using UnityEngine;

namespace StateMachines.PlayerStates.MoveStates
{
    public class IdleState :  MovementPlayerState
    {
        public IdleState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            PlayerAnimator.DoIdleMove();
            MonoBehaviour.print("Entering Idle State");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Idle State");
        }
    }
}