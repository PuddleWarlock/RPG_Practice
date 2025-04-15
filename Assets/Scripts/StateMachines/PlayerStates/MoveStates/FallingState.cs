using Anims;
using Controllers.Entities;
using UnityEngine;

namespace StateMachines.PlayerStates.MoveStates
{
    public class FallingState : MovementPlayerState
    {
        public FallingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering Falling State");
            PlayerAnimator.DoFalling();
        }

        public override void Execute()
        {
            MovementController.InertialMove();
        }

        public override void Exit()
        {
            Debug.Log("Exiting Falling State");
            PlayerAnimator.DoLanding();
        }
    }
}