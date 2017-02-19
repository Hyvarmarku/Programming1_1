using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Utility;

namespace TAMKShooter.Systems
{
    public class Global : MonoBehaviour
    {
        private static Global _instance;

        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject globalObj = new GameObject(typeof(Global).Name);
                    _instance = globalObj.AddComponent<Global>();
                }

                return _instance;
            }
        }

        [SerializeField]
        private Prefabs _prefabs;
        [SerializeField]
        private Pools _pools;

        public Prefabs prefabs { get { return _prefabs; } }
        public Pools pools { get { return _pools; } }
        public GameManager gameManager { get; private set; }
        public int maxPlayers;

        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            if (_instance == this)
            {
                Init();
            }
            else
            {
                Destroy(this);
            }
        }

        private void Init()
        {
            DontDestroyOnLoad(gameObject);

            if (_prefabs == null)
                _prefabs = GetComponentInChildren<Prefabs>();
            if (_pools == null)
                _pools = GetComponentInChildren<Pools>();

            gameManager = gameObject.GetOrAddComponent<GameManager>();
            gameManager.Init();
        }
    }
}
