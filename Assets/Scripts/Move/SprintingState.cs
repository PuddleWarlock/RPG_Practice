using Base;
using UnityEngine;

namespace Move
{
    public class SprintingState : BasePlayerState
    {
        public SprintingState(MovementController movementController) : base(movementController)
        {
        }

        public override void Enter()
        {
            MovementController.moveSpeed = 20f;
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
