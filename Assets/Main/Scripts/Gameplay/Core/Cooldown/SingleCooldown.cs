using UnityEngine;

namespace Main.Scripts.Gameplay.Core.Cooldown
{
    public class SingleCooldown
    {
        private float _lastCooldownTime = 0;
        private float _cooldown = 0;

        public bool Ended => Time.time - _lastCooldownTime >= _cooldown;
        
        public SingleCooldown SetCooldown(float cooldown)
        {
            _cooldown = cooldown;
            return this;
        }

        public void Reset()
        {
            _lastCooldownTime = Time.time;
        }
    }
}