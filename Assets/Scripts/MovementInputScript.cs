using System;
using TestShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(JumpInputScript))]
    internal class MovementInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerInputScript _input;

        [SerializeField] private GameObject _player;
        private Rigidbody _rigidbody;
        private JumpInputScript _jumpInput;

        [Range(0f, 10f), SerializeField] private float speed = 3f;

        private Vector2 moveDirection;

        void Awake()
        {
            _rigidbody = _player.GetComponent<Rigidbody>() ?? throw new ArgumentException(nameof(_player));
            _jumpInput = this.GetComponent<JumpInputScript>();
        }

        void OnEnable()
        {
            _input.Input.Moving.Move.performed += Move_performed;
            _input.Input.Moving.Move.canceled += Move_performed;
        }

        void OnDisable()
        {
            _input.Input.Moving.Move.performed -= Move_performed;
            _input.Input.Moving.Move.canceled += Move_performed;
        }

        private void Move_performed(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            var move = (_player.transform.right * moveDirection.x
                + _player.transform.forward * moveDirection.y);

            var distanse = new Vector3(move.x, 0, move.z) * speed;

            distanse *= _jumpInput.IsGrounded ? 1f : 0.5f;

            _rigidbody.MovePosition(_player.transform.position + distanse * Time.fixedDeltaTime);

        }
    }
}
