using Anims;
using Controllers.Entities;
using UnityEngine;

namespace StateMachines.PlayerStates.MoveStates
{
    public class WalkingState: MovementPlayerState
    {
        public WalkingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Walking State");
            PlayerAnimator.DoWalk();
            MovementController.moveSpeed = 2f;
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