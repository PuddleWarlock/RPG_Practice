using Base;
using UnityEngine;

namespace Move
{
    public class WalkingState: BasePlayerState
    {
        public WalkingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Walking State");
            PlayerController.moveSpeed = 10f;
        }

        public override void Execute()
        {
            PlayerController.Move();
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Walking State");
        }
    }
}