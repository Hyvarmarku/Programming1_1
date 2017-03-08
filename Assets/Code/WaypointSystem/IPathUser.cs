using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TAMKShooter.WaypointSystem
{
    public enum Direction
    {
        Forward,
        Backward
    }

    public enum PathType
    {
        Loop,
        PingPong,
        OneWay
    }

    public interface IPathUser
    {
        Waypoint CurrentWayPoint { get; }
        Direction Direction { get; set; }
        Vector3 Position { get; set; }

        void Init(IMover mover, Path waypointSystem);
    }
}
