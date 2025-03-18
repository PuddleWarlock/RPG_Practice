using System;
using Base;
using StateMachines;
using UnityEngine;

namespace Move
{
    public class WalkingState: MovementPlayerState
    {
        public WalkingState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            MonoBehaviour.print("Entering Walking State");
            PlayerAnimator.DoWalk();
            MovementController.moveSpeed = 5f;
        }

        public override void Execute()
        {
            MovementController.Move();
        }

        public override void Exit()
        {
            PlayerAnimator.DoIdleMove();
            MonoBehaviour.print("Exiting Walking State");
            
        }
    }
}