using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    internal class UnitScript : MonoBehaviour
    {
        private Rigidbody _rigidbody;

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
            }
        }
    }
}
