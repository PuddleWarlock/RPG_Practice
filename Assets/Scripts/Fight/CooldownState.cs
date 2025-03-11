using Move;
using UnityEngine;

namespace Fight
{
    public class CooldownState :  BasePlayerState
    {
        private float _timer = 0f;

        public CooldownState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            _timer = 0f;
        }

        public override void Execute()
        {
            _timer += Time.deltaTime;
            if (_timer >= 2f)
            {
                PlayerController.ChangeState(new IdleAttackState());
            }
        }

        public override void Exit()
        {
        }
        
    }
}