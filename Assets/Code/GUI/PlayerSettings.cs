using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
    public class PlayerSettings : Window
    {
        public int PlayerCount { get; private set; }

        [SerializeField]
        private Dropdown _playerCountDropdown;
        [SerializeField]
        private PlayerSettingsItem[] _playerSettingsItems;
        private MenuManager _menuManager;

        public void Init(MenuManager menuManager)
        {
            _playerCountDropdown.onValueChanged.AddListener(OnValueChanged);
            _playerCountDropdown.value = 0;
            OnValueChanged(0);

            _menuManager = menuManager;
            foreach (var playerSettingItem in _playerSettingsItems)
            {
                playerSettingItem.Init();
            }
        }

        public void StartGame()
        {
            List<PlayerData> playerDatas = new List<PlayerData>();
            for (int i = 0; i < PlayerCount; i++)
            {
                var settingsItem = _playerSettingsItems[i];
                var playerData = new PlayerData()
                {
                    controllerType = settingsItem.Controller,
                    playerId = settingsItem.PlayerId,
                    unitType = settingsItem.UnitType,
                    lives = Configs.Config.Lives                
                };
                playerDatas.Add(playerData);
            }
            _menuManager.StartGame(playerDatas);
        }

        private void OnValueChanged(int index)
        {
            int playerCount;
            if (int.TryParse(_playerCountDropdown.options[index].text, out playerCount))
            {
                PlayerCount = playerCount;
                for (int i = 0; i < _playerSettingsItems.Length; i++)
                {
                    _playerSettingsItems[i].gameObject.SetActive(PlayerCount > i);
                }
            } 
        }
    }
}