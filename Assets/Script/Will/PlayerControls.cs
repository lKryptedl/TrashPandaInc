//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Script/Will/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""a5038ddf-cfc4-4beb-9b8e-d322cb2716f1"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a0d112b6-9789-4cc7-8244-40174654e2dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gravity"",
                    ""type"": ""Button"",
                    ""id"": ""d62bcd95-3e7f-47a2-8fe5-2d0d3d41f94e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8ca6a303-177d-4475-b1f3-aeff53a8e9a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Suck"",
                    ""type"": ""Button"",
                    ""id"": ""d01b52cd-9f49-417d-94b3-40c2efddb7e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b573ef00-75c6-41e7-b111-589fcafd93cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b6f8c9ff-cac2-4c0e-a95b-7f86001d8e3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change"",
                    ""type"": ""Button"",
                    ""id"": ""8c9648d5-0b5a-4d1d-b82b-226eeee6712c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rocket"",
                    ""type"": ""Button"",
                    ""id"": ""19f8279d-3866-44a7-a98e-850069a0db92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f87a7af-c9e1-433c-8f90-d19b3a64d75f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6c617d3-d48f-4ff6-a396-7872fc450ec8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""25fc0a25-e2bd-4a50-ba9e-33d55d7e2c79"",
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
                    ""id"": ""3f54b08c-85dc-45c0-aeed-6b314dba45b5"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""156bc145-929d-4daa-90db-78448187d8fb"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fcd6cd52-4289-4b0c-8d36-8dbe80dfaf83"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f8f7fc9-9f5a-4d4f-97f7-48fca4ae5872"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2eeee989-cdf3-4bbb-961f-c5192b5b90d2"",
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
                    ""id"": ""aeeb80d3-127d-489a-bb38-363442d64024"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b0041b43-ad34-43b0-babe-51190384254c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38e90994-fcb2-45f8-b569-319a3c67595f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""693443de-a32e-4e11-8b2c-2dc0c5d88450"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a60fc07b-14f9-471a-a435-88d89d5cf2e3"",
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
                    ""id"": ""9ae6859b-f634-4396-b706-8f322590017c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e2d33ee0-dbda-4ca3-8692-ddd2db983d61"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=40,y=30)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac2b28ef-fe2b-4f2a-bfae-10f1e94ae555"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ae18e3d-2b5b-47c4-ac12-e77ac508f366"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e6df47b-8df5-49fb-86f9-9a082ebbf609"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""72988bcc-4fc1-4105-a858-dc1db51c6524"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e133c303-9015-4095-810d-b31cabd2fcd9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f901f8bf-9cb0-4b4c-bc01-6b924884bd02"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40afe291-2f84-4855-8d01-902af2b7aeda"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11a3aba9-d7b3-4b27-9032-4781ee8b9b1d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rocket"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Jump = m_Newactionmap.FindAction("Jump", throwIfNotFound: true);
        m_Newactionmap_Gravity = m_Newactionmap.FindAction("Gravity", throwIfNotFound: true);
        m_Newactionmap_Move = m_Newactionmap.FindAction("Move", throwIfNotFound: true);
        m_Newactionmap_Suck = m_Newactionmap.FindAction("Suck", throwIfNotFound: true);
        m_Newactionmap_Shoot = m_Newactionmap.FindAction("Shoot", throwIfNotFound: true);
        m_Newactionmap_Look = m_Newactionmap.FindAction("Look", throwIfNotFound: true);
        m_Newactionmap_Change = m_Newactionmap.FindAction("Change", throwIfNotFound: true);
        m_Newactionmap_Rocket = m_Newactionmap.FindAction("Rocket", throwIfNotFound: true);
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

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Jump;
    private readonly InputAction m_Newactionmap_Gravity;
    private readonly InputAction m_Newactionmap_Move;
    private readonly InputAction m_Newactionmap_Suck;
    private readonly InputAction m_Newactionmap_Shoot;
    private readonly InputAction m_Newactionmap_Look;
    private readonly InputAction m_Newactionmap_Change;
    private readonly InputAction m_Newactionmap_Rocket;
    public struct NewactionmapActions
    {
        private @PlayerControls m_Wrapper;
        public NewactionmapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Newactionmap_Jump;
        public InputAction @Gravity => m_Wrapper.m_Newactionmap_Gravity;
        public InputAction @Move => m_Wrapper.m_Newactionmap_Move;
        public InputAction @Suck => m_Wrapper.m_Newactionmap_Suck;
        public InputAction @Shoot => m_Wrapper.m_Newactionmap_Shoot;
        public InputAction @Look => m_Wrapper.m_Newactionmap_Look;
        public InputAction @Change => m_Wrapper.m_Newactionmap_Change;
        public InputAction @Rocket => m_Wrapper.m_Newactionmap_Rocket;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnJump;
                @Gravity.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnGravity;
                @Gravity.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnGravity;
                @Gravity.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnGravity;
                @Move.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @Suck.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSuck;
                @Suck.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSuck;
                @Suck.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSuck;
                @Shoot.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnShoot;
                @Look.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Change.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnChange;
                @Change.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnChange;
                @Change.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnChange;
                @Rocket.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnRocket;
                @Rocket.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnRocket;
                @Rocket.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnRocket;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Gravity.started += instance.OnGravity;
                @Gravity.performed += instance.OnGravity;
                @Gravity.canceled += instance.OnGravity;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Suck.started += instance.OnSuck;
                @Suck.performed += instance.OnSuck;
                @Suck.canceled += instance.OnSuck;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Change.started += instance.OnChange;
                @Change.performed += instance.OnChange;
                @Change.canceled += instance.OnChange;
                @Rocket.started += instance.OnRocket;
                @Rocket.performed += instance.OnRocket;
                @Rocket.canceled += instance.OnRocket;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface INewactionmapActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnGravity(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSuck(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnChange(InputAction.CallbackContext context);
        void OnRocket(InputAction.CallbackContext context);
    }
}
