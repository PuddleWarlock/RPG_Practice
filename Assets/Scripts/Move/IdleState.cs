using System;
using Base;
using StateMachines;
using UnityEngine;

namespace Move
{
    public class IdleState :  MovementPlayerState
    {
        public IdleState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
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