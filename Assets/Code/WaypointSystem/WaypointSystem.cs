using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TAMKShooter.WaypointSystem
{

    public class Path : MonoBehaviour
    {
        public List<Waypoint> Waypoints
        {
            get
            {
                if (_waypoints == null || _waypoints.Count == 0 || !Application.isPlaying)
                {
                    _waypoints = GetComponentsInChildren<Waypoint>().ToList();
                }
                return _waypoints;
            }
        }

        [SerializeField]
        private PathType _pathType;
        private List<Waypoint> _waypoints;
        private readonly Dictionary<PathType, Color> _pathColors =
            new Dictionary<PathType, Color>()
            {
                {PathType.Loop, Color.green },
                {PathType.PingPong, Color.red },
                {PathType.OneWay, Color.blue }
            };

        private void OnDrawGizmos()
        {
            Gizmos.color = _pathColors[_pathType];
            if (_waypoints.Count > 1)
            {
                for (int i = 1; i < _waypoints.Count; ++i)
                {
                    Gizmos.DrawLine(Waypoints[i -1].Position, Waypoints[i].Position);
                }
                if (_pathType == PathType.Loop)
                {
                    Gizmos.DrawLine(Waypoints[_waypoints.Count - 1].Position, Waypoints[0].Position);
                }
            }
        }
    }
}
