using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAMKShooter.Data
{
    [Serializable]
    public class GameData
    {
        public List<PlayerData> PlayerDatas = new List<Data.PlayerData>();
        public int Level;
    }
}
