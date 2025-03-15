using Base;
using UnityEngine;

namespace Move
{
    public class JumpingState : BasePlayerState
    {
        public JumpingState(MovementController movementController) : base(movementController)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Jumping State");
            MovementController.Jump();
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