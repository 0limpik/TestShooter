using UnityEngine;

namespace TestShooter.Scripts.Movement
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    internal class JumpScript : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private CapsuleCollider _capsuleCollider;

        private bool isJump;
        public bool IsGrounded { get; private set; }

        private float jumpForse;

        private float slopeLimit = 45f;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        public void Jump(float jumpForse)
        {
            this.jumpForse = jumpForse;
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
                    jumpForse = 0f;
                }
                isJump = false;
            }
        }

        private void CheckGrounded()
        {
            IsGrounded = false;
            float capsuleHeight = Mathf.Max(_capsuleCollider.radius * 2f, _capsuleCollider.height);
            Vector3 capsuleBottom = transform.TransformPoint(_capsuleCollider.center - Vector3.up * capsuleHeight / 2f);
            float radius = transform.TransformVector(_capsuleCollider.radius, 0f, 0f).magnitude;
            Ray ray = new Ray(capsuleBottom + transform.up * .01f, -transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, radius * 5f))
            {
                float normalAngle = Vector3.Angle(hit.normal, transform.up);
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
