using Fight;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Base;

namespace Enemy
{
    public class AttackState : StatesEnemyConst
    {
        private SkillsController _skillsController;
        public AttackState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent, SkillsController skillsController) : base(enemyController, animator, navMeshAgent)
        {
            _skillsController = skillsController;
        }

        public override void Enter()
        {
            _skillsController.Skills[SkillType.Melee].Cast();
            EnemyController._sword.ClearEnemiesList();
            Debug.Log("Entering ENEMY ATTACK");
            EnemyAnimator.DoAttack();
            NavMeshAgent.isStopped = true;
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}