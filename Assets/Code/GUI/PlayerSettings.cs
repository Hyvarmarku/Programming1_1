using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
    public class PlayerSettings : Window
    {
        [SerializeField]
        private Dropdown _playerCountDropdown;
        [SerializeField]
        private PlayerSettingsItem[] _playerSettingsItems;
        private MenuManager _menuManager;

        public void Init(MenuManager menuManager)
        {
            _menuManager = menuManager;
            foreach (var playerSettingItem in _playerSettingsItems)
            {
                playerSettingItem.Init();
            }
        }
    }
}