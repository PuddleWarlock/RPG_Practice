using Base;
using Fight;

namespace StateMachines
{
    public abstract class FightPlayerState : IPlayerState
    {
        protected FightController FightController;
        protected CooldownSystem CooldownSystem;
        protected PlayerAnimator PlayerAnimator;
        
        protected FightPlayerState(FightController fightController, CooldownSystem cooldownSystem, PlayerAnimator animator)
        {
            FightController = fightController;
            CooldownSystem = cooldownSystem;
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