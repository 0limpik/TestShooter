using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    internal class GunScript : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletSpawner { get; private set; }
        [SerializeField] private BulletScript bulletPrefab;

        [Range(0f, 2.5f), SerializeField] private float shootDelay = 0.5f;
        private float lastShootTime;

        [Range(0f, 100f), SerializeField] private float bulletSpeed = 35f;

        public void Shoot()
        {
            if (lastShootTime + shootDelay < Time.time)
            {
                lastShootTime = Time.time;
                var bullet = GameObject.Instantiate(bulletPrefab, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
            }
        }

    }
}
