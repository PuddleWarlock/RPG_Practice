using Move;

namespace Fight
{
    public class IdleAttackState : BasePlayerState
    {
        public IdleAttackState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
        }

        public override void Execute( )
        {
            if (PlayerController.AttackInput)
            {
                PlayerController.ChangeState(new AttackState());
            }
        }

        public override void Exit( )
        {
        }
    }
}