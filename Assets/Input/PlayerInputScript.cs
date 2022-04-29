using UnityEngine;

namespace TestShooter.Input
{
    internal class PlayerInputScript : MonoBehaviour
    {
        public static PlayerInput Input => _Input ??= new PlayerInput();
        private static PlayerInput _Input;

        void OnEnable()
        {
            Input.Enable();
        }

        void OnDisable()
        {
            Input.Disable();
        }
    }
}
