using Base;
using UnityEngine;

namespace Move
{
    public class WalkingState: BasePlayerState
    {
        public WalkingState(MovementController movementController) : base(movementController)
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