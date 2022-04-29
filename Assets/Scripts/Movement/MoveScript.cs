using UnityEngine;

namespace TestShooter.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(JumpScript))]
    internal class MoveScript : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private JumpScript _jumpScript;

        [HideInInspector] public Vector2 distanse;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _jumpScript = GetComponent<JumpScript>();
        }

        void FixedUpdate()
        {
            distanse *= _jumpScript.IsGrounded ? 1f : 0.5f;

            _rigidbody.MovePosition(transform.position + new Vector3(distanse.x, 0, distanse.y) * Time.fixedDeltaTime);
        }
    }
}
