//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Script/James/Shooting Controls.inputactions
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

public partial class @ShootingControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShootingControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Shooting Controls"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""eea518d2-acb5-4908-ae08-c568c09f07ec"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e9da3a8a-28fc-4a5b-a7a6-e6c312e9f880"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Suck"",
                    ""type"": ""Button"",
                    ""id"": ""04d0cadd-2434-42f2-af5c-b052f6aacf20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rocket"",
                    ""type"": ""Button"",
                    ""id"": ""c7255fc8-287c-4746-858a-3cc159d492e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""475a4120-308d-446a-bd9b-156953b2b778"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ResetAim"",
                    ""type"": ""Button"",
                    ""id"": ""48f540d0-680b-4d44-8db4-d2220278f798"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9d9cb982-a2be-47a4-8395-d0519e8a0479"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dba1e8a-931b-416b-877e-f417cce9bad0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Suck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e04147c0-69e6-47bb-97e1-1b02b30bfbcf"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rocket"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45d1659-6b35-4c98-ba0b-a41ccd2c0a5b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d144c8f-5f5f-4224-adcb-0758f5c4ef44"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Control
        m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
        m_Control_Shoot = m_Control.FindAction("Shoot", throwIfNotFound: true);
        m_Control_Suck = m_Control.FindAction("Suck", throwIfNotFound: true);
        m_Control_Rocket = m_Control.FindAction("Rocket", throwIfNotFound: true);
        m_Control_Aim = m_Control.FindAction("Aim", throwIfNotFound: true);
        m_Control_ResetAim = m_Control.FindAction("ResetAim", throwIfNotFound: true);
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

    // Control
    private readonly InputActionMap m_Control;
    private IControlActions m_ControlActionsCallbackInterface;
    private readonly InputAction m_Control_Shoot;
    private readonly InputAction m_Control_Suck;
    private readonly InputAction m_Control_Rocket;
    private readonly InputAction m_Control_Aim;
    private readonly InputAction m_Control_ResetAim;
    public struct ControlActions
    {
        private @ShootingControls m_Wrapper;
        public ControlActions(@ShootingControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Control_Shoot;
        public InputAction @Suck => m_Wrapper.m_Control_Suck;
        public InputAction @Rocket => m_Wrapper.m_Control_Rocket;
        public InputAction @Aim => m_Wrapper.m_Control_Aim;
        public InputAction @ResetAim => m_Wrapper.m_Control_ResetAim;
        public InputActionMap Get() { return m_Wrapper.m_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void SetCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Suck.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnSuck;
                @Suck.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnSuck;
                @Suck.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnSuck;
                @Rocket.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRocket;
                @Rocket.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRocket;
                @Rocket.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRocket;
                @Aim.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnAim;
                @ResetAim.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnResetAim;
                @ResetAim.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnResetAim;
                @ResetAim.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnResetAim;
            }
            m_Wrapper.m_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Suck.started += instance.OnSuck;
                @Suck.performed += instance.OnSuck;
                @Suck.canceled += instance.OnSuck;
                @Rocket.started += instance.OnRocket;
                @Rocket.performed += instance.OnRocket;
                @Rocket.canceled += instance.OnRocket;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @ResetAim.started += instance.OnResetAim;
                @ResetAim.performed += instance.OnResetAim;
                @ResetAim.canceled += instance.OnResetAim;
            }
        }
    }
    public ControlActions @Control => new ControlActions(this);
    public interface IControlActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnSuck(InputAction.CallbackContext context);
        void OnRocket(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnResetAim(InputAction.CallbackContext context);
    }
}
