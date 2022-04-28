using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(GunScript))]
    internal class EnemyShootScript : MonoBehaviour
    {
        private GunScript _gun;
        [SerializeField] private Transform _unit;
        [SerializeField] private Transform _player;

        void Awake()
        {
            _gun = this.GetComponent<GunScript>();
        }

        void Update()
        {
            _gun.transform.LookAt(_player.transform.position);
        }

        private void FixedUpdate()
        {
            if(Physics.Raycast(_gun.BulletSpawner.position, _gun.BulletSpawner.forward, out RaycastHit hit))
            {
                if(hit.collider.gameObject == _player.gameObject)
                {
                    _gun.Shoot();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if(_gun?.BulletSpawner != null)
            {
                Gizmos.DrawLine(_gun.BulletSpawner.position, _gun.BulletSpawner.forward * 100f);
            }
        }
    }
}
