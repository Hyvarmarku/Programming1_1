using System;
using UnityEngine;


namespace TAMKShooter
{
    public class Mover : MonoBehaviour, IMover
    {
        [SerializeField]
        private float _speed;

        public Vector3 position
        {
            get{ return transform.position; }

            set{ transform.position = value; }
        }

        public Quaternion rotation
        {
            get { return transform.rotation; }

            set{ transform.rotation = value; }
        }

        public float speed
        {
            get { return _speed; }
        }

        public void MoveToDirection(Vector3 direction)
        {
            direction = direction.normalized;
            position += direction * speed * Time.deltaTime;
        }

        public void MoveTowardPosition(Vector3 target)
        {
            Vector3 direction = target - position;
            MoveToDirection(direction);
        }

        public void RotateTowardPosition(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - position;
            direction.y = position.y;
            direction = direction.normalized;
            Vector3 newRot = Vector3.RotateTowards(transform.forward, direction, speed * Time.deltaTime, 0);

            rotation = Quaternion.LookRotation(newRot);
        }
    }
}
