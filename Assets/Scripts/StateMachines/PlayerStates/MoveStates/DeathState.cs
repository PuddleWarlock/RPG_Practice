﻿using Anims;
using Controllers.Entities;
using UnityEngine;

namespace StateMachines.PlayerStates.MoveStates
{
    public class DeathState : MovementPlayerState
    {
        public DeathState(MovementController movementController, PlayerAnimator animator) : base(movementController, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering Death State");
            PlayerAnimator.DoDeath();
        }

        public override void Execute()
        {
           
        }

        public override void Exit()
        {
        }
    }
}