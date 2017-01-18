using UnityEngine;

namespace TAMKShooter
{
    public interface IMover
    {
        //Position of this object in world space
        Vector3 position { get; set; }
        //Rotation of this object in world space
        Quaternion rotation { get; set; }
        //The speed of this mover
        float speed { get; }

        //Moves toward target position
        void MoveTowardPosition(Vector3 target);
        //Moves to direction
        void MoveToDirection(Vector3 direction);
        //Rotates toward 'targetPosition'.
        void RotateTowardPosition(Vector3 targetPosition);
    }
}
