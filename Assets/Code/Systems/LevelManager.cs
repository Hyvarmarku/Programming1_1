using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class LevelManager : SceneManager
    {
        [SerializeField]
        private PlayerUnits _playerUnits;

        public PlayerUnits playerUnits
        {
            get { return _playerUnits; }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {

        }

    }
}