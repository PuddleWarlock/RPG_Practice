using Fight;
using Unity.VisualScripting;
using UnityEngine;
using Weapons.Base;
using Weapons.Colliding;

namespace Weapons
{
    public class SpellSkill : Skill
    {
        //private readonly Transform _caster;
        private readonly GameObject _spellProjectile;
        private readonly Transform _castPoint;
        private readonly Transform _camera;


        public SpellSkill(SkillData skillData,GameObject spellProjectile, Transform castPoint, Transform caster, Transform camera) : base(skillData)
        {
            _spellProjectile = spellProjectile;
            _castPoint = castPoint;
            //_caster = caster;
            _camera = camera;
        }

        public override void Cast()
        {
            base.Cast();
            var obj = Object.Instantiate(_spellProjectile,_castPoint.position, Quaternion.identity);
            var proj = obj.AddComponent<Projectile>();
            proj.Init(new Damage(DamageType.Magic,20f), _castPoint.GetComponentInParent<IDamageable>());
            var rb = obj.GetComponent<Rigidbody>();
            int layerMask = ~LayerMask.GetMask("Player");
            Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, 1000f,layerMask);
            Vector3 castDir =  hit.point - _castPoint.position;
            rb.AddForce(castDir.normalized * 1000f);
            proj.StartCoroutine(proj.Ttl());
        }
    }
}