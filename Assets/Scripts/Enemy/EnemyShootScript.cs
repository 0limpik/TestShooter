using TestShooter.Scripts.Weapon;
using UnityEngine;

namespace TestShooter.Scripts.Enemy
{
    [RequireComponent(typeof(GunScript))]
    internal class EnemyShootScript : MonoBehaviour
    {
        private GunScript _gun;
        [SerializeField] private Transform _playerUnit;
        [SerializeField] private float distanseHeightModifuer = 0.1f;

        void Awake()
        {
            _gun = GetComponent<GunScript>();
        }

        void Update()
        {
            _gun.transform.LookAt(_playerUnit.transform.position);

            var distanse = _gun.BulletSpawner.transform.position - _playerUnit.transform.position;
            _gun.BulletSpawner.LookAt(_playerUnit.transform.position + new Vector3(0, distanse.magnitude * distanseHeightModifuer, 0));
        }

        private void FixedUpdate()
        {
            var direction = _playerUnit.transform.position - _gun.BulletSpawner.transform.position;

            if (Physics.Raycast(_gun.BulletSpawner.position, direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject == _playerUnit.gameObject)
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
                var direction = _playerUnit.transform.position - _gun.BulletSpawner.transform.position;
                Gizmos.DrawLine(_gun.BulletSpawner.position, direction * 100f);
            }
        }
    }
}
