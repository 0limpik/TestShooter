using UnityEngine;

namespace TestShooter.Input
{
    internal class PlayerInputScript : MonoBehaviour
    {
        public PlayerInput Input { get; private set; }

        void Awake()
        {
            Input = new PlayerInput();
        }

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
