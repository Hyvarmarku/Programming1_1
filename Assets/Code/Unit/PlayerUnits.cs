using UnityEngine;
using TAMKShooter.Data;
using System.Collections.Generic;
using TAMKShooter.Systems;
using System;

namespace TAMKShooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private int maxPlayers;
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();
        private int playersCreated;
        private InputManager inputManager;
        private PlayerSpawnManager _playerSpawner;

        public void Init(params PlayerData[] players)
        {
            maxPlayers = Global.Instance.maxPlayers;
            inputManager = FindObjectOfType<InputManager>();
            _playerSpawner = GetComponentInChildren<PlayerSpawnManager>();

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
                PlayerUnit unit = SpawnPlayer(pd);

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
                Debug.LogError("FAILED TO ADD A NEW PLAYER. (CURRENT) " + playersCreated + " / " + maxPlayers + " (MAX ALLOWED)");
            }
        }

        public void PlayerDied(PlayerUnit playerUnit)
        {
            bool arePlayersAlive = false;
            foreach (var player in _players.Values)
            {
                if (player.data.lives > 0)
                {
                    arePlayersAlive = true;
                }
            }
            if (!arePlayersAlive)
            {
                Global.Instance.gameManager.PerformTransition(GameStateTransitionType.InGameToGameOver);
            }
        }

        public void ReSpawnPlayer(PlayerUnit player)
        {
            _playerSpawner.RespawnPlayer(player);
        }

        private PlayerUnit SpawnPlayer(PlayerData pd)
        {
           return _playerSpawner.SpawnPlayer(pd);
        }
    }
}
