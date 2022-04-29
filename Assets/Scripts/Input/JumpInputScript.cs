using TestShooter.Input;
using TestShooter.Scripts.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts.Input
{
    internal class JumpInputScript : MonoBehaviour
    {
        [SerializeField] private JumpScript _jumpScript;

        [Range(0f, 1000f), SerializeField] private float jumpForse = 300;

        void Awake()
        {

        }

        void OnEnable()
        {
            PlayerInputScript.Input.Moving.Jump.performed += Jump_performed;
        }

        void OnDisable()
        {
            PlayerInputScript.Input.Moving.Jump.performed += Jump_performed;
        }

        private void Jump_performed(InputAction.CallbackContext obj)
        {
            _jumpScript.Jump(jumpForse);
        }
    }
}
