using System;
using Base;
using UnityEngine;

namespace Move
{
    public class IdleState :  BasePlayerState
    {
        public IdleState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Idle State");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            MonoBehaviour.print("Exiting Idle State");
        }
    }
}