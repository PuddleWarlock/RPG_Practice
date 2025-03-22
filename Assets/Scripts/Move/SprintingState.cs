using Base;
using StateMachines;
using UnityEngine;

namespace Move
{
    public class SprintingState : MovementPlayerState
    {
        public SprintingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            PlayerAnimator.DoRun();
            MovementController.moveSpeed = 5f;
            MonoBehaviour.print("Entering Sprinting State");
        }

        public override void Execute()
        {
            MovementController.Move();
        }

        public override void Exit()
        {
            PlayerAnimator.DoIdleMove();
            MonoBehaviour.print("Exiting Sprinting State");
        }
    }
}
