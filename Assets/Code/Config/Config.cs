using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Configs
{
    public static class Config
    {
        public const string MenuSceneName = "Menu";

        public static readonly Dictionary<int, string> levelNames = new Dictionary<int, string>()
        {
            {1, "Level1" },
            {2, "Level2" }
        };

        public const string GameOverSceneName = "GameOver";

        public const string PlayerProjectileLayerName = "PlayerProjectile";
        public const string EnemyProjectileLayerName = "EnemyProjectile";

        public const string ArrowHorizontal = "ArrowHorizontal";
        public const string ArrowVertical = "ArrowVertical";
        public const string ArrowShoot = "ArrowShoot";

        public const string WasdHorizontal = "WasdHorizontal";
        public const string WasdVecrical = "WasdVertical";
        public const string WasdShoot = "WasdShoot";

        public const string PadOneHorizontal = "Pad1Horizontal";
        public const string PadOneVertical = "Pad1Vertical";
        public const string PadOneShoot = "Pad1Shoot";

        public const string PadTwoHorizontal = "Pad2Horizontal";
        public const string PadTwoVertical = "Pad2Vertical";
        public const string PadTwoShoot = "Pad2Shoot";
        public const int Lives = 3;
    }
}
