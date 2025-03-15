using Base;
using Move;
using UnityEngine;

namespace Fight
{
    public class IdleAttackState : BasePlayerState
    {
        public IdleAttackState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering IdleAttack");
        }

        public override void Execute( )
        {
        }

        public override void Exit( )
        {
            Debug.Log("Exiting IdleAttack");
        }
    }
}