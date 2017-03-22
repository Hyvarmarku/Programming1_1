﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
    public class PlayerUnitSelector : MonoBehaviour
    {
        public PlayerUnit.UnitType SelectedUnitType { get; private set; }
        private Dropdown _dropdown;

        public void Init()
        {
            _dropdown = GetComponentInChildren<Dropdown>();
            _dropdown.ClearOptions();
            var optionDataList = new List<Dropdown.OptionData>();

            foreach (var playerUnitType in Enum.GetValues(typeof(PlayerUnit.UnitType)))
            {
                if((PlayerUnit.UnitType) playerUnitType != PlayerUnit.UnitType.None)
                    optionDataList.Add(new Dropdown.OptionData(playerUnitType.ToString()));
            }
            _dropdown.AddOptions(optionDataList);
            _dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(int index)
        {
            string selectionText = _dropdown.options[index].text;
            SelectedUnitType = (PlayerUnit.UnitType) Enum.Parse(typeof(PlayerUnit.UnitType), selectionText);
        }
    }
}