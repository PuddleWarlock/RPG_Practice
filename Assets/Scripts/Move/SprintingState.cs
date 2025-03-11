using UnityEngine;

namespace Move
{
    public class SprintingState : IPlayerState
    {
        public void Enter(PlayerController playerController)
        {
            playerController.moveSpeed = 20f;
        }

        public void Execute(PlayerController playerController)
        {
            MonoBehaviour.print("Sprinting");
            playerController.Move();
            if (!playerController.SprintInput)
            {
                playerController.ChangeState(new WalkingState());
            }
            else if(playerController.JumpInput) playerController.ChangeState(new JumpingState());
        }

        public void Exit(PlayerController playerController)
        {
        }
    }
}
