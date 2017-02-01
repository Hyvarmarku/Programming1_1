using UnityEngine;
using TAMKShooter.Data;
using System.Collections.Generic;

namespace TAMKShooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach (PlayerData pd in players)
            {

            }
        }
    }
}
