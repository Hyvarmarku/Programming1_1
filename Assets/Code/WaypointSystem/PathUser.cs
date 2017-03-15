using UnityEngine;

namespace TAMKShooter.WaypointSystem
{
    public class PathUser : MonoBehaviour, IPathUser
    {
        #region Unity Fields
        [SerializeField]
        private Direction _direction;
        [SerializeField]
        private float _arriveDistance = 0.1f;
        #endregion

        private IMover _mover;
        private Path _path;
        private bool _isInitialized = false;
        private float _sqrArriveDistance;

        public Waypoint CurrentWayPoint
        {
            get;
            private set;
        }

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3 Position
        {
            get{ return transform.position; }
            set{ transform.position = value; }
        }

        public void Init(IMover mover, Path path)
        {
            _sqrArriveDistance = _arriveDistance * _arriveDistance;
            _mover = mover;
            _path = path;
            if (_path != null)
            {
                CurrentWayPoint = _path.GetClosestWaypoint(Position);
                _isInitialized = true;
            }
        }

        protected void Update()
        {
            if (!_isInitialized)
                return;

            CurrentWayPoint = GetWaypoint();
            if (CurrentWayPoint != null)
            {
                Vector3 direction = CurrentWayPoint.Position - Position;
                _mover.MoveToDirection(direction);
                _mover.RotateTowardPosition(CurrentWayPoint.Position);
            }
        }
        
        private Waypoint GetWaypoint()
        {
            Waypoint result = CurrentWayPoint;
            if (result == null)
                return null;

            Vector3 toWaypointVector = CurrentWayPoint.Position - Position;
            float waypointVectorSwrMagnitude = toWaypointVector.sqrMagnitude;
            if (waypointVectorSwrMagnitude <= _sqrArriveDistance)
            {
                result = _path.GetNextWaypoint(CurrentWayPoint, ref _direction);
            }

            return result;
        }

    }
}
