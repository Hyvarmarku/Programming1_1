using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;

namespace TAMKShooter.Systems
{
    public class InputManager : MonoBehaviour
    {
        private PlayerUnit[] _players;

        public void Init(PlayerUnit[] units)
        {
            _players = units;
        }

        void Update()
        {
            foreach (PlayerUnit unit in _players)
            {
                Move(unit);
            }
        }

        void Move(PlayerUnit unit)
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
