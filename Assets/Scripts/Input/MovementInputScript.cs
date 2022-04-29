﻿using TestShooter.Input;
using TestShooter.Scripts.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts.Input
{
    internal class MovementInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerInputScript _input;
        [SerializeField] private MoveScript _moveScript;
        [SerializeField] private GameObject _player;

        [Range(0f, 10f), SerializeField] private float speed = 3f;

        private Vector2 moveDirection;

        void Awake()
        {

        }

        void OnEnable()
        {
            PlayerInputScript.Input.Moving.Move.performed += Move_performed;
            PlayerInputScript.Input.Moving.Move.canceled += Move_performed;
        }

        void OnDisable()
        {
            PlayerInputScript.Input.Moving.Move.performed -= Move_performed;
            PlayerInputScript.Input.Moving.Move.canceled += Move_performed;
        }

        private void Move_performed(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            var move = _player.transform.right * moveDirection.x
                + _player.transform.forward * moveDirection.y;

            var distanse = new Vector2(move.x, move.z) * speed;

            _moveScript.distanse = distanse;
        }
    }
}