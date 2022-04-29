using TestShooter.Scripts.Weapon;
using UnityEngine;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(GunScript))]
    internal class EnemyShootScript : MonoBehaviour
    {
        private GunScript _gun;
        [SerializeField] private Transform _unit;
        [SerializeField] private Transform _player;
        [SerializeField] private float distanseHeightModifuer = 0.1f;

        void Awake()
        {
            _gun = this.GetComponent<GunScript>();
        }

        void Update()
        {
            _gun.transform.LookAt(_player.transform.position);

            var distanse = _gun.BulletSpawner.transform.position - _player.transform.position;
            _gun.BulletSpawner.LookAt(_player.transform.position + new Vector3(0, distanse.magnitude * distanseHeightModifuer, 0));
        }

        private void FixedUpdate()
        {
            var direction = _player.transform.position - _gun.BulletSpawner.transform.position;

            if (Physics.Raycast(_gun.BulletSpawner.position, direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    _gun.Shoot();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (_gun?.BulletSpawner != null)
            {
                var direction = _player.transform.position - _gun.BulletSpawner.transform.position;
                Gizmos.DrawLine(_gun.BulletSpawner.position, direction * 100f);
            }
        }
    }
}
