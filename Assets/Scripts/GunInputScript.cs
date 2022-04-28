using Assets.Scripts;
using TestShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts
{
    [RequireComponent(typeof(GunScript))]
    internal class GunInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerInputScript _input;

        [SerializeField] private GunScript gun;

        private bool shoot;

        void Awake()
        {
            gun = this.GetComponent<GunScript>();
        }

        void OnEnable()
        {
            _input.Input.Weapon.Shoot.started += Shoot_started; ;
            _input.Input.Weapon.Shoot.canceled += Shoot_canceled;
        }

        void OnDisable()
        {
            _input.Input.Weapon.Shoot.started -= Shoot_started;
            _input.Input.Weapon.Shoot.canceled += Shoot_canceled;
        }

        private void Shoot_canceled(InputAction.CallbackContext context)
        {
            shoot = false;
        }

        private void Shoot_started(InputAction.CallbackContext context)
        {
            shoot = true;
        }

        void Update()
        {
            if (shoot)
            {
                gun.Shoot();
            }
        }

    }
}
