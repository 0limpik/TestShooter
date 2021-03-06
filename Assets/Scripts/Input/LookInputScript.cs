using TestShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts.Input
{
    internal class LookInputScript : MonoBehaviour
    {
        [SerializeField] private GameObject _playerUnit;
        private Camera _camera;

        [Range(1f, 15f), SerializeField] private float sensivityX = 5f;
        [Range(1f, 15f), SerializeField] private float sensivityY = 5f;
        [Range(30f, 89f), SerializeField] private float maxLookAngle = 85f;

        private Vector2 lookDelta;

        void Awake()
        {
            _camera = Camera.main;
        }

        void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerInputScript.Input.Look.Rotation.performed += CameraMovement;
        }

        void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerInputScript.Input.Look.Rotation.performed -= CameraMovement;
        }

        private void CameraMovement(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>() * Time.deltaTime;
            lookDelta += new Vector2(delta.x * sensivityX, delta.y * sensivityY);
        }

        void Update()
        {
            _playerUnit.transform.Rotate(new Vector3(0f, lookDelta.x, 0f));

            var x = _camera.transform.rotation.eulerAngles.x;
            x = x < 180 ? x : (360 - x) * -1;
            var y = Mathf.Clamp(x - lookDelta.y, -maxLookAngle, maxLookAngle) - x;
            _camera.transform.Rotate(new Vector3(y, 0f, 0f));

            lookDelta = Vector2.zero;
        }
    }
}
