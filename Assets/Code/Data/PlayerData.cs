using System;

namespace TAMKShooter.Data
{
    [Serializable]
    public class PlayerData
    {
        public enum PlayerId
        {
            None = 0,
            Player1 = 1,
            Player2 = 2,
            Player3 = 3,
            Player4 = 4
        }

        public enum ControllerType
        {
            None = 0,
            WASD = 1,
            Arrow = 2,
            GamepadOne = 3,
            GamepadTwo = 4
        }

        public PlayerId playerId;
        public PlayerUnit.UnitType unitType;
        public ControllerType controllerType;
        public int lives;
    }
}
