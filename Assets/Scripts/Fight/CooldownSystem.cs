using UnityEditor.Media;
using UnityEngine;

namespace Fight
{
    public class CooldownSystem
    {
        public bool MeleeReady;
        public bool SpellReady;
        private float _meleeTimer = 3f;
        private float _spellTimer = 5f;

        public void Tick()
        {
            _meleeTimer += Time.deltaTime;
            _spellTimer += Time.deltaTime;
            if (_meleeTimer > 3f)
            {
                MeleeReady = true;
                _meleeTimer = 0f;
            }

            if (_spellTimer > 5f)
            {
                SpellReady = true;
                _spellTimer = 0f;
            }
        }
    }
}