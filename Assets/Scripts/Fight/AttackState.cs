using Move;
using UnityEngine;

namespace Fight
{
    public class AttackState : BasePlayerState
    {
        public AttackState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.DoAttack();
        }

        public override void Execute()
        {
            if (Mathf.Approximately(PlayerController._animator.GetCurrentAnimatorStateInfo(1).normalizedTime, 1))
            {
                PlayerController.ChangeState(new CooldownState());
            }
        }

        public override void Exit()
        {
            
        }
    }
}