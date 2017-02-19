using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;

namespace TAMKShooter.Systems
{
    public class InputManager : MonoBehaviour
    {
        private int _maxPlayers;
        private PlayerUnit[] _players;

        //This is called when the game is launched for the first time.
        public void Init(PlayerUnit[] units)
        {
            _maxPlayers = Global.Instance.maxPlayers;
            _players = new PlayerUnit[_maxPlayers];

            for (int i = 0; i < _players.Length; i++)
            {
                AddNewPlayer(units[i],i);
            }
        }

        //This is called if more players are added in the run time.
        public void AddNewPlayer(PlayerUnit unit, int index)
        {
            _players[index] = unit;
        }

        void Update()
        {
            foreach (PlayerUnit unit in _players)
            {
                UpdateUnitsInput(unit);
            }
        }

        void UpdateUnitsInput(PlayerUnit unit)
        {
            PlayerData.ControllerType controller = unit.data.controllerType;
            string horizontalAxis = "";
            string verticalAxis = "";
            string shootInput = "";

            switch (controller)
            {
                case PlayerData.ControllerType.Arrow:
                    horizontalAxis = Configs.Config.ArrowHorizontal;
                    verticalAxis = Configs.Config.ArrowVertical;
                    shootInput = Configs.Config.ArrowShoot;
                    break;

                case PlayerData.ControllerType.WASD:
                    horizontalAxis = Configs.Config.WasdHorizontal;
                    verticalAxis = Configs.Config.WasdVecrical;
                    shootInput = Configs.Config.WasdShoot;
                    break;

                case PlayerData.ControllerType.GamepadOne:
                    horizontalAxis = Configs.Config.PadOneHorizontal;
                    verticalAxis = Configs.Config.PadOneVertical;
                    shootInput = Configs.Config.PadOneShoot;
                    break;

                case PlayerData.ControllerType.GamepadTwo:
                    horizontalAxis = Configs.Config.PadTwoHorizontal;
                    verticalAxis = Configs.Config.PadTwoVertical;
                    shootInput = Configs.Config.PadTwoShoot;
                    break;
            }

            float dirX = Input.GetAxis(horizontalAxis);
            float dirZ = Input.GetAxis(verticalAxis);

            Vector3 direction = new Vector3(dirX, 0, dirZ);
            unit.mover.MoveToDirection(direction);

            bool shoot = Input.GetButton(shootInput);

            if (shoot)
            {
                unit.weapons.Shoot(unit.projectileLayer);
            }
        }
    }
}
