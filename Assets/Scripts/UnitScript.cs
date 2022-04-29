using System;
using TestShooter.Scripts.Weapon;
using UnityEngine;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    internal class UnitScript : MonoBehaviour
    {
        public event Action<GameObject> OnHit;

        private Rigidbody _rigidbody;
        [field: SerializeField] public GameObject Owner { get; private set; }
        [field: SerializeField] public GunScript GunScript { get; private set; }

        void Awake()
        {
            _rigidbody = this.GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var bullet = collision.gameObject.GetComponent<BulletScript>();

            if (bullet != null)
            {
                var flatDirection = new Vector3(bullet.ShootDirection.x, 0, bullet.ShootDirection.z);
                var rightDirection = Quaternion.AngleAxis(90, Vector3.up) * flatDirection;
                var direction = Quaternion.AngleAxis(360 - bullet.KnockbackAngle, rightDirection) * flatDirection;
                _rigidbody.AddForce(direction * bullet.KnockbackForce, ForceMode.Impulse);
                OnHit?.Invoke(bullet.shooter);
            }
        }
    }
}
