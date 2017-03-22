using System;
using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
    public class ControlerSelector : MonoBehaviour
    {
        public PlayerData.PlayerId Id { get; private set; }
        public PlayerData.ControllerType Controller { get; private set; }

        private Dropdown _dropdown;

        public void Init(PlayerData.PlayerId id, PlayerData.ControllerType defaultControllerType)
        {
            _dropdown = GetComponentInChildren<Dropdown>(true);
            _dropdown.ClearOptions();
            List<Dropdown.OptionData> optionDataList = new List<Dropdown.OptionData>();

            foreach (var controllerType in Enum.GetValues(typeof(PlayerData.ControllerType)))
            {
                if ((PlayerData.ControllerType)controllerType != PlayerData.ControllerType.None)
                {
                    string controllerName = InputManager.GetControllerName((PlayerData.ControllerType)controllerType);
                    optionDataList.Add(new Dropdown.OptionData(controllerName));
                }
            }

            _dropdown.AddOptions(optionDataList);
            _dropdown.onValueChanged.AddListener(OnValueChanged);

            Id = id;
            Controller = defaultControllerType;

            int defaultIndex = GetItemIndex(InputManager.GetControllerName(defaultControllerType));
            if (defaultIndex > 0)
            {
                _dropdown.value = defaultIndex;
            }
        }

        private void OnValueChanged(int index)
        {
            Controller = InputManager.GetControllerTypeByName(_dropdown.options[index].text);
        }

        private int GetItemIndex(string controllerName)
        {
            int result = -1;

            for (int i = 0; i < _dropdown.options.Count; i++)
            {
                Dropdown.OptionData optionData = _dropdown.options[i];
                if (optionData.text == controllerName)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
