﻿using System.Collections;
using Base;
using StateMachines;
using UnityEngine;
using Weapons.Base;

namespace Fight
{
    public class SpellState : FightPlayerState
    {
        public SpellState(FightController fightController, SkillsController skillsController, PlayerAnimator animator) : base(fightController, skillsController, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering Spell");
            PlayerAnimator.DoSpell();
            //FightController.swordGameObject.SetActive(false);
            PlayerAnimator.StartCoroutine(SpellCast());

        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            //FightController.swordGameObject.SetActive(true);
            Debug.Log("Exiting Spell");
        }

        private IEnumerator SpellCast()
        {
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.425f, "Spell"));
            SkillsController.Skills[SkillType.Fireball].Cast();
        }
    }
}