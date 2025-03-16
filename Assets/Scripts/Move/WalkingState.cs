using Base;
using StateMachines;
using UnityEngine;

namespace Move
{
    public class WalkingState: MovementPlayerState
    {
        public WalkingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Walking State");
            MovementController.moveSpeed = 10f;
        }

        public override void Execute()
        {
            MovementController.Move();
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Walking State");
        }
    }
}