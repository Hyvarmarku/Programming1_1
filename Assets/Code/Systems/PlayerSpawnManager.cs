using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class PlayerSpawnManager : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _playerSpawnPositions = new List<Transform>();

        public PlayerUnit SpawnPlayer(PlayerData pd)
        {
            PlayerUnit unitPrefab = Global.Instance.prefabs.GetUnitPrefabByType(pd.unitType);
            PlayerUnit unit = Instantiate(unitPrefab, transform);
            unit.transform.position = GetSpawnPosition(pd.playerId);
            unit.transform.rotation = Quaternion.identity;
            unit.Init(pd);
            return unit;
        }

        public void RespawnPlayer(PlayerUnit player)
        {
            player.transform.position = GetSpawnPosition(player.data.playerId);
            player.health.ResetHealth(true);
        }

        private Vector3 GetSpawnPosition(PlayerData.PlayerId playerId)
        {
            var result = Vector3.zero;
            switch (playerId)
            {
                case PlayerData.PlayerId.Player1:
                    result = _playerSpawnPositions[0].position;
                    break;
                case PlayerData.PlayerId.Player2:
                    result = _playerSpawnPositions[1].position;
                    break;
                case PlayerData.PlayerId.Player3:
                    result = _playerSpawnPositions[2].position;
                    break;
                case PlayerData.PlayerId.Player4:
                    result = _playerSpawnPositions[3].position;
                    break;
            }
            return result;
        }
    }
}
