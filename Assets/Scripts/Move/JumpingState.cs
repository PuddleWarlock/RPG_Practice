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
            PlayerController.Jump();
        }

        public override void Execute()
        {
            MonoBehaviour.print("Falling");
            PlayerController.moveSpeed -= 2f * Time.deltaTime;
            PlayerController.Move();
            if (PlayerController.IsGrounded)
            {
                PlayerController.ChangeState(new IdleState());
            }
        }

        public override void Exit()
        {
        }
    }
}