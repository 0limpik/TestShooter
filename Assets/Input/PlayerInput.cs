//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from TestShooter/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TestShooter.Input
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Look"",
            ""id"": ""6a6d0dd2-1d61-4ce9-a226-bd6e2a043af0"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""087a649d-77f6-49f5-827d-0bfa6740f5c1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2acfbd7-375e-4ec2-9a60-7f7c440ad35d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Moving"",
            ""id"": ""a721605a-74cb-4b7f-bc0e-68557d911a87"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""91c54d7b-b434-4b1a-a0d7-9da0af673b83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5186aee1-e195-4f38-84d6-3027e34158cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6fa496ae-87fc-4171-88b2-56a08c6ccea1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""59dc191a-273d-4340-bf01-ef57c536b5e8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""82644a0d-7c26-40b0-9cb1-504bd1333251"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3a17783f-e5d9-4388-8d50-57650ade2ba3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4090522-bffe-4ebb-877d-fe6a0880cef9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6c13e04-25a2-483d-a969-484d36b13697"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Weapon"",
            ""id"": ""6f1ee808-2647-440d-98e3-e1a63ee41f57"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5dd26815-de44-4e67-9e99-d2323b6dd2f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4807ae26-d486-4c9d-9a86-fc8e0a111973"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ac02507-f383-430c-ae9b-1be112dda156"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c4e3cbc-913b-4b62-8fed-d05c6d1c1651"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Look
            m_Look = asset.FindActionMap("Look", throwIfNotFound: true);
            m_Look_Rotation = m_Look.FindAction("Rotation", throwIfNotFound: true);
            // Moving
            m_Moving = asset.FindActionMap("Moving", throwIfNotFound: true);
            m_Moving_Move = m_Moving.FindAction("Move", throwIfNotFound: true);
            m_Moving_Jump = m_Moving.FindAction("Jump", throwIfNotFound: true);
            // Weapon
            m_Weapon = asset.FindActionMap("Weapon", throwIfNotFound: true);
            m_Weapon_Shoot = m_Weapon.FindAction("Shoot", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Look
        private readonly InputActionMap m_Look;
        private ILookActions m_LookActionsCallbackInterface;
        private readonly InputAction m_Look_Rotation;
        public struct LookActions
        {
            private @PlayerInput m_Wrapper;
            public LookActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_Look_Rotation;
            public InputActionMap Get() { return m_Wrapper.m_Look; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LookActions set) { return set.Get(); }
            public void SetCallbacks(ILookActions instance)
            {
                if (m_Wrapper.m_LookActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_LookActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_LookActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_LookActionsCallbackInterface.OnRotation;
                }
                m_Wrapper.m_LookActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                }
            }
        }
        public LookActions @Look => new LookActions(this);

        // Moving
        private readonly InputActionMap m_Moving;
        private IMovingActions m_MovingActionsCallbackInterface;
        private readonly InputAction m_Moving_Move;
        private readonly InputAction m_Moving_Jump;
        public struct MovingActions
        {
            private @PlayerInput m_Wrapper;
            public MovingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Moving_Move;
            public InputAction @Jump => m_Wrapper.m_Moving_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Moving; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovingActions set) { return set.Get(); }
            public void SetCallbacks(IMovingActions instance)
            {
                if (m_Wrapper.m_MovingActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_MovingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public MovingActions @Moving => new MovingActions(this);

        // Weapon
        private readonly InputActionMap m_Weapon;
        private IWeaponActions m_WeaponActionsCallbackInterface;
        private readonly InputAction m_Weapon_Shoot;
        public struct WeaponActions
        {
            private @PlayerInput m_Wrapper;
            public WeaponActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Shoot => m_Wrapper.m_Weapon_Shoot;
            public InputActionMap Get() { return m_Wrapper.m_Weapon; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WeaponActions set) { return set.Get(); }
            public void SetCallbacks(IWeaponActions instance)
            {
                if (m_Wrapper.m_WeaponActionsCallbackInterface != null)
                {
                    @Shoot.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                }
                m_Wrapper.m_WeaponActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                }
            }
        }
        public WeaponActions @Weapon => new WeaponActions(this);
        private int m_MouseKeyboardSchemeIndex = -1;
        public InputControlScheme MouseKeyboardScheme
        {
            get
            {
                if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
                return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
            }
        }
        public interface ILookActions
        {
            void OnRotation(InputAction.CallbackContext context);
        }
        public interface IMovingActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IWeaponActions
        {
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}
