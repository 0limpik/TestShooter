using System;
using UnityEngine;

namespace TestShooter.Scripts.Weapon
{
    [Serializable]
    internal class GunScript : MonoBehaviour
    {
        public event Action OnShoot;

        [field: SerializeField] public Transform BulletSpawner { get; private set; }
        [SerializeField] private BulletScript _bulletPrefab;

        [SerializeField] private GameObject _shooter;

        [Range(0f, 2.5f), SerializeField] private float shootDelay = 0.5f;
        private float lastShootTime;

        [Range(0f, 100f), SerializeField] private float bulletSpeed = 35f;

        public void Shoot()
        {
            if (lastShootTime + shootDelay < Time.time)
            {
                lastShootTime = Time.time;
                var bullet = Instantiate(_bulletPrefab, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
                bullet.shooter = _shooter;
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
                OnShoot?.Invoke();
            }
        }
    }
}
