using UnityEngine;
using System.Collections.Generic;

namespace TAMKShooter.Systems
{
    public class Prefabs : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerUnit> _unitPrefabs = new List<PlayerUnit>();

        public PlayerUnit GetUnitPrefabByType(PlayerUnit.UnitType unitType)
        {
            foreach (PlayerUnit unit in _unitPrefabs)
            {
                if (unit.type == unitType)
                {
                    return unit;
                }
            }

            return null;
        }
    }
}
