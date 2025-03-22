using Base;
using Fight;

namespace StateMachines
{
    public abstract class FightPlayerState : IPlayerState
    {
        protected FightController FightController;
        protected SkillsController SkillsController;
        protected PlayerAnimator PlayerAnimator;
        
        protected FightPlayerState(FightController fightController, SkillsController skillsController, PlayerAnimator animator)
        {
            FightController = fightController;
            SkillsController = skillsController;
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