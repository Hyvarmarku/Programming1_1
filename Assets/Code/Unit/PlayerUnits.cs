using UnityEngine;
using TAMKShooter.Data;
using System.Collections.Generic;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private int maxPlayers;
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();
        private int playersCreated;
        private InputManager inputManager;

        public void Init(params PlayerData[] players)
        {
            maxPlayers = Global.Instance.maxPlayers;
            inputManager = FindObjectOfType<InputManager>();

            foreach (PlayerData pd in players)
            {
                CreatePlayer(pd,true);
            }

            PlayerUnit[] unitsToPass = new PlayerUnit[_players.Count];
            _players.Values.CopyTo(unitsToPass,0);

            inputManager.Init(unitsToPass);
        }

        public void CreatePlayer(PlayerData pd, bool firstInit = false)
        {
            // Won't allow you to add more players than maxPlayers allows to. To prevent bugs.
            if (playersCreated < maxPlayers)
            {
                PlayerUnit unitPrefab = Global.Instance.prefabs.GetUnitPrefabByType(pd.unitType);
                if (unitPrefab != null)
                {
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = Vector3.zero;
                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(pd);

                    // New unit is send to the InputManager immediately unless it's the beginning of the game. 
                    // Otherwise the new units are passed to the manager in InputManager.Init() method.
                    if (!firstInit)
                    {
                        inputManager.AddNewPlayer(unit,playersCreated);
                    }

                    _players.Add(pd.playerId, unit);
                    playersCreated++;
                }
                else
                {
                    Debug.LogError("UNIT TYPE NOT FOUND: " + pd.unitType);
                }
            }
            else
            {
                Debug.LogError("FAILED TO ADD A NEW PLAYER. (CURRENT) " + playersCreated + " / " + maxPlayers + " (MAX ALLOWED)");
            }
        }
    }
}
