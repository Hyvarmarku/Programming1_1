using UnityEngine;
using TAMKShooter.Data;
using System.Collections.Generic;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach (PlayerData pd in players)
            {
                PlayerUnit unitPrefab = Global.Instance.prefabs.GetUnitPrefabByType(pd.unitType);

                if (unitPrefab != null)
                {
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = Vector3.zero;
                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(pd);

                    _players.Add(pd.playerId, unit);
                }
                else
                {
                    Debug.LogError("UNIT TYPE NOT FOUND: " + pd.unitType);
                }
            }

            InputManager inputManager = FindObjectOfType<InputManager>();
            PlayerUnit[] unitsToPass = new PlayerUnit[_players.Count];
            _players.Values.CopyTo(unitsToPass,0);

            inputManager.Init(unitsToPass);
        }

        // Update player movement
    }
}
