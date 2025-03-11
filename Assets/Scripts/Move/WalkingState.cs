using UnityEngine;

namespace Move
{
    public class WalkingState: IPlayerState
    {
        public void Enter(PlayerController playerController)
        {
            MonoBehaviour.print("Entering Walking State");
            playerController.moveSpeed = 10f;
        }

        public void Execute(PlayerController playerController)
        {
            MonoBehaviour.print("Walking");
            playerController.Move();
            if (playerController.MoveInput.magnitude == 0)
            {
                playerController.ChangeState(new IdleState());
            }
            else if (playerController.JumpInput)
            {
                playerController.ChangeState(new JumpingState());
            }
            else if (playerController.SprintInput)
            {
                playerController.ChangeState(new SprintingState());
            }

        }

        public void Exit(PlayerController playerController)
        {
            MonoBehaviour.print("Exiting Walking State");
        }
    }
}