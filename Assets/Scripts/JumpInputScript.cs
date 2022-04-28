using System;
using TestShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts
{

    internal class JumpInputScript : MonoBehaviour
    {
        private const float onGroundSphereRadius = 0.1f;

        [SerializeField] private PlayerInputScript _input;

        [SerializeField] private GameObject _player;
        private Rigidbody _rigidbody;
        private CapsuleCollider _capsuleCollider;

        [Range(0f, 1000f), SerializeField] private float jumpForse = 300;
        private bool isJump;

        [Tooltip("Maximum slope the character can jump on")]
        [Range(5f, 60f)]
        public float slopeLimit = 45f;

        [SerializeField] private LayerMask groundMask;
        public bool IsGrounded { get; private set; }

        void Awake()
        {
            _rigidbody = _player.GetComponent<Rigidbody>() ?? throw new ArgumentException(nameof(_player));
            _capsuleCollider = _player.GetComponent<CapsuleCollider>() ?? throw new ArgumentException(nameof(_player));
        }

        void OnEnable()
        {
            _input.Input.Moving.Jump.performed += Jump_performed;
        }

        void OnDisable()
        {
            _input.Input.Moving.Jump.performed += Jump_performed;
        }

        private void Jump_performed(InputAction.CallbackContext obj)
        {
            isJump = true;
        }

        void FixedUpdate()
        {
            CheckGrounded();
            if (isJump)
            {
                if (IsGrounded)
                {
                    _rigidbody.AddForce(Vector3.up * jumpForse, ForceMode.Impulse);
                }
                isJump = false;
            }
        }

        private void CheckGrounded()
        {
            IsGrounded = false;
            float capsuleHeight = Mathf.Max(_capsuleCollider.radius * 2f, _capsuleCollider.height);
            Vector3 capsuleBottom = _player.transform.TransformPoint(_capsuleCollider.center - Vector3.up * capsuleHeight / 2f);
            float radius = _player.transform.TransformVector(_capsuleCollider.radius, 0f, 0f).magnitude;

            Ray ray = new Ray(capsuleBottom + _player.transform.up * .01f, -_player.transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, radius * 5f))
            {
                float normalAngle = Vector3.Angle(hit.normal, _player.transform.up);
                if (normalAngle < slopeLimit)
                {
                    float maxDist = radius / Mathf.Cos(Mathf.Deg2Rad * normalAngle) - radius + .02f;
                    if (hit.distance < maxDist)
                        IsGrounded = true;
                }
            }
        }
    }
}
