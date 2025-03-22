using Base;
using StateMachines;
using UnityEngine;

namespace Move
{
    public class JumpingState : MovementPlayerState
    {
        public JumpingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Jumping State");
            // MovementController.Jump();
            PlayerAnimator.DoJump();
        }

        public override void Execute()
        {
            MovementController.moveSpeed -= 2f * Time.deltaTime;
            MovementController.Move();
        }

        public override void Exit()
        {   
            MonoBehaviour.print("Exiting Jumping State");
        }
    }
}