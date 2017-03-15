using System;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class Pools : MonoBehaviour
    {
        [SerializeField]
        private List<ProjectilePool> _projectilePool = new List<ProjectilePool>();
        [SerializeField]
        private AsteroidPool _asteroidPool;

        public AsteroidPool AsteroidPool { get { return _asteroidPool; } }

        public ProjectilePool GetPool(Projectile.ProjectileType projectileType)
        {
            ProjectilePool result = null;

            foreach (ProjectilePool pp in _projectilePool)
            {
                if (pp.projectileType == projectileType)
                {
                    result = pp;
                    break;
                }
            }

            return result;
        }
    }
}
