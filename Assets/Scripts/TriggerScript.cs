using System;
using UnityEngine;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(Collider))]
    internal class TriggerScript : MonoBehaviour
    {
        public event Action<Collider> OnTrigger;

        private Collider _collider;

        void Awake()
        {
            _collider = this.GetComponent<Collider>();
        }

        void OnTriggerEnter(Collider other)
        {
            OnTrigger?.Invoke(other);
        }
    }
}
