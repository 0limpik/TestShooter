using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    internal class BulletScript : MonoBehaviour
    {
        [field: SerializeField] public float KnockbackForce { get; private set; } = 3f;
        [field: SerializeField] public float KnockbackAngle { get; private set; } = 45f;

        private Vector3 shootPostion;
        public Vector3 ShootDirection => (this.transform.position - shootPostion).normalized;

        private MeshRenderer _meshRenderer;
        private Rigidbody _rigidbody;
        private Collider _collider;
        [SerializeField] private ParticleSystem _particleSystem;

        public GameObject shooter;

        void Awake()
        {
            _meshRenderer = this.GetComponent<MeshRenderer>();
            _rigidbody = this.GetComponent<Rigidbody>();
            _collider = this.GetComponent<Collider>();

            shootPostion = this.transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(nameof(Destroy));
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
            Destroy(this.gameObject);
        }
    }
}
