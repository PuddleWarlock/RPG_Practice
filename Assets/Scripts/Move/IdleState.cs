using UnityEngine;

namespace Move
{
    public class IdleState :  IPlayerState
    {
        public void Enter(PlayerController playerController)
        {
            MonoBehaviour.print("Entering Idle State");
        }

        public void Execute(PlayerController playerController)
        {
            MonoBehaviour.print("Idle");
            if (playerController.MoveInput.magnitude > 0)
            {
                playerController.ChangeState(new WalkingState());
            }
            else if (playerController.JumpInput)
            {
                playerController.ChangeState(new JumpingState());
            }
        }

        public void Exit(PlayerController playerController)
        {
            MonoBehaviour.print("Exiting Idle State");
        }
    }
}