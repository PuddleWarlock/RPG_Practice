﻿using Base;

namespace StateMachines
{
    public abstract class MovementPlayerState : IState
    {
        protected MovementController MovementController;
        protected PlayerAnimator PlayerAnimator;
        
        protected MovementPlayerState(MovementController movementController, PlayerAnimator animator)
        {
            MovementController = movementController;
            PlayerAnimator = animator;
        }
        
        public virtual void Enter()
        {
        }

        public virtual void Execute()
        {
        }

        public virtual void Exit()
        {
        }
    }
}