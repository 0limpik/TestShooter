using TestShooter.Input;
using TestShooter.Scripts.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestShooter.Scripts.Input
{
    [RequireComponent(typeof(GunScript))]
    internal class GunInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerInputScript _input;

        private GunScript gun;

        private bool shoot;

        void Awake()
        {
            gun = GetComponent<GunScript>();
        }

        void OnEnable()
        {
            PlayerInputScript.Input.Weapon.Shoot.started += Shoot_started; ;
            PlayerInputScript.Input.Weapon.Shoot.canceled += Shoot_canceled;
        }

        void OnDisable()
        {
            PlayerInputScript.Input.Weapon.Shoot.started -= Shoot_started;
            PlayerInputScript.Input.Weapon.Shoot.canceled += Shoot_canceled;
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
