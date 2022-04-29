using System.Collections;
using UnityEngine;

namespace TestShooter.Scripts.Weapon
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    internal class BulletScript : MonoBehaviour
    {
        [field: SerializeField] public float KnockbackForce { get; private set; } = 3f;
        [field: SerializeField] public float KnockbackAngle { get; private set; } = 45f;
        [SerializeField] public float lifetime = 10f;

        private Vector3 shootPostion;
        public Vector3 ShootDirection => (transform.position - shootPostion).normalized;

        private MeshRenderer _meshRenderer;
        private Rigidbody _rigidbody;
        private Collider _collider;
        [SerializeField] private ParticleSystem _particleSystem;

        public GameObject shooter;

        void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();

            shootPostion = transform.position;

            StartCoroutine(nameof(DestroyOutOfLifeTime));
        }

        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(nameof(Destroy));
            StopCoroutine(nameof(DestroyOutOfLifeTime));
        }

        IEnumerator Destroy()
        {
            _meshRenderer.enabled = false;
            _collider.enabled = false;
            _rigidbody.drag = 100f;
            _particleSystem.Play();

            while (_particleSystem.IsAlive())
            {
                yield return null;
            }

            Destroy(gameObject);
        }

        IEnumerator DestroyOutOfLifeTime()
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
    }
}
