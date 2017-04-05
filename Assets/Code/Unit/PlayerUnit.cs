using System;
using UnityEngine;
using TAMKShooter.Data;
using TAMKShooter.Configs;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class PlayerUnit : UnitBase
    {

        [SerializeField]
        private UnitType _type;
        public UnitType type
        {
            get { return _type; }
        }
        public PlayerData data { get; private set; }

        public override int projectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.PlayerProjectileLayerName);
            }
        }

        public void Init(PlayerData playerData)
        {
            InitRequiredComponents();
            data = playerData;
        }

        protected override void Die()
        {
            data.lives -= 1;

            if (data.lives > 0)
            {
                //TODO: Change this
                FindObjectOfType<PlayerUnits>().ReSpawnPlayer(this);
            }
            else
            {
                FindObjectOfType<PlayerUnits>().PlayerDied(this);
                gameObject.SetActive(false);
            }
        }

        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 3,
            Heavy = 4
        }
    }
}
