using Fight;
using Unity.VisualScripting;
using UnityEngine;
using Weapons.Base;
using Weapons.Colliding;

namespace Weapons
{
    public class SpellSkill : Skill
    {
        private Transform _caster;
        private readonly GameObject _spellProjectile;
        private readonly Transform _castPoint;


        public SpellSkill(SkillData skillData,GameObject spellProjectile, Transform castPoint, Transform caster) : base(skillData)
        {
            _spellProjectile = spellProjectile;
            _castPoint = castPoint;
            _caster = caster;
        }

        public override void Cast()
        {
            base.Cast();
            var obj = Object.Instantiate(_spellProjectile,_castPoint.position, Quaternion.identity);
            var proj = obj.AddComponent<Projectile>();
            proj.Init(new Damage(DamageType.Magic,20f), _caster.GetComponentInParent<IDamageable>());
            proj.StartCoroutine(proj.Ttl());
            var rb = obj.GetComponent<Rigidbody>();
            
            rb.AddForce((_caster.forward + new Vector3(0, .1f, 0)) * 1000f);
        }
    }
}