using System;
using UnityEngine;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(Collider))]
    internal class TriggerScript : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent;
        public event Action<Collider> OnTriggerExitEvent;

        private Collider _collider;

        void Awake()
        {
            _collider = this.GetComponent<Collider>();
        }

        void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }
        void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }
    }
}
