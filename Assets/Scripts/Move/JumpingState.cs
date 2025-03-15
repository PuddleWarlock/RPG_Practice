using Base;
using UnityEngine;

namespace Move
{
    public class JumpingState : BasePlayerState
    {
        public JumpingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Jumping State");
            PlayerController.Jump();
        }

        public override void Execute()
        {
            PlayerController.moveSpeed -= 2f * Time.deltaTime;
            PlayerController.Move();
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Jumping State");
        }
    }
}