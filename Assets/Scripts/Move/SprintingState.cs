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
            MovementController.moveSpeed = MovementController.runSpeed;
            MonoBehaviour.print("Entering Sprinting State");
        }

        public override void Execute()
        {
            MovementController.Move();
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Sprinting State");
        }
    }
}
