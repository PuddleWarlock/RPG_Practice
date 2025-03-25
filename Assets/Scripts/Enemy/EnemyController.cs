using Fight;
using StateMachines;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private StateMachine enemyStateMachine;
        private EnemyAnimator enemyAnimator;
        private HealthSystem healthSystem;
        private void Awake()
        {
            enemyStateMachine = new StateMachine();
            enemyAnimator = GetComponent<EnemyAnimator>();
            healthSystem = GetComponent<HealthSystem>();
        }

        private void Start()
        {
            EnemyStatesInit();
        }

        private void Update()
        {
            enemyStateMachine.Tick();
        }

        private void EnemyStatesInit()
        {
            var idleState = new IdleState(this,enemyAnimator);
            // var walkState =  new WalkState(this,enemyAnimator);
            var deathState = new DeathState(this,enemyAnimator);
            
            // bool death() => enemyAnimator._animator.GetCurrentAnimatorStateInfo(0).IsName("Death");
            
            enemyStateMachine.AddTransition(idleState, deathState, () => healthSystem.Health <= 0f);
            enemyStateMachine.SetState(idleState);
        }
        
}
}