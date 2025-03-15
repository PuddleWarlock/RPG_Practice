using Base;
using Move;
using UnityEngine;

namespace Fight
{
    public class IdleAttackState : BasePlayerState
    {
        public IdleAttackState(MovementController movementController) : base(movementController)
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