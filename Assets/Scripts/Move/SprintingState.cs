using Base;
using UnityEngine;

namespace Move
{
    public class SprintingState : BasePlayerState
    {
        public SprintingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.moveSpeed = 20f;
            MonoBehaviour.print("Entering Sprinting State");
        }

        public override void Execute()
        {
            PlayerController.Move();
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Sprinting State");
        }
    }
}
