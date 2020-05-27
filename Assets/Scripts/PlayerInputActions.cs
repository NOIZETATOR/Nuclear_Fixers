// GENERATED AUTOMATICALLY FROM 'Assets/Settings/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""61e7fea7-6b53-473b-9d01-9d8d7ef43188"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3392ce85-bf9b-4caf-80e2-e2811a0fb5d8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c58fc8cb-120c-48a8-b5d6-fdf5118fc690"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f3935ba2-027b-4cae-8076-2b1535d0fe00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""PassThrough"",
                    ""id"": ""628f810c-7393-439e-bc09-d13479ec819f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action_X"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a7616aa5-9add-4f23-bb59-e284aa463a76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Action_Y"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2a088e2d-a61b-457c-92f8-20b1b3c9cf6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Action_B"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d8d6296d-d398-4a36-896f-4ab3b19b2d64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RightJoystickRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ae115fe4-de21-41ba-b1b2-c8034a16eb2b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8091b21f-a9be-4d44-b734-8cd7b1135c72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""PassThrough"",
                    ""id"": ""12b4b790-7b00-45bc-9e6d-8d7ca9b45a4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ff97c47-2a07-447d-855d-c69ef0dfa4e9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c795d169-d32c-49a7-b78d-bbfa77a2666c"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71c07f19-c364-4458-8fa8-4c4a2698f38a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4973031c-251b-40d0-af66-de2e9e18afbe"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Action_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c26019a-98b2-474c-8e87-fc6be57d7c63"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Action_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d530d7ec-aa6e-439f-afcd-17bdbfc8d357"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Action_B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40ce3a65-b78f-4a4c-b0b0-611dd96cacd0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""RightJoystickRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7cd80b-33a3-4c34-b82d-e4b7b7d21fe4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05c096b3-ac7c-4a89-8a0d-a368a523505d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0850fbb-54ba-4cb4-b106-4bac25bc9793"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox"",
            ""bindingGroup"": ""Xbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_Push = m_PlayerControls.FindAction("Push", throwIfNotFound: true);
        m_PlayerControls_Drop = m_PlayerControls.FindAction("Drop", throwIfNotFound: true);
        m_PlayerControls_Action_X = m_PlayerControls.FindAction("Action_X", throwIfNotFound: true);
        m_PlayerControls_Action_Y = m_PlayerControls.FindAction("Action_Y", throwIfNotFound: true);
        m_PlayerControls_Action_B = m_PlayerControls.FindAction("Action_B", throwIfNotFound: true);
        m_PlayerControls_RightJoystickRotation = m_PlayerControls.FindAction("RightJoystickRotation", throwIfNotFound: true);
        m_PlayerControls_Exit = m_PlayerControls.FindAction("Exit", throwIfNotFound: true);
        m_PlayerControls_Start = m_PlayerControls.FindAction("Start", throwIfNotFound: true);
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

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_Push;
    private readonly InputAction m_PlayerControls_Drop;
    private readonly InputAction m_PlayerControls_Action_X;
    private readonly InputAction m_PlayerControls_Action_Y;
    private readonly InputAction m_PlayerControls_Action_B;
    private readonly InputAction m_PlayerControls_RightJoystickRotation;
    private readonly InputAction m_PlayerControls_Exit;
    private readonly InputAction m_PlayerControls_Start;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @Push => m_Wrapper.m_PlayerControls_Push;
        public InputAction @Drop => m_Wrapper.m_PlayerControls_Drop;
        public InputAction @Action_X => m_Wrapper.m_PlayerControls_Action_X;
        public InputAction @Action_Y => m_Wrapper.m_PlayerControls_Action_Y;
        public InputAction @Action_B => m_Wrapper.m_PlayerControls_Action_B;
        public InputAction @RightJoystickRotation => m_Wrapper.m_PlayerControls_RightJoystickRotation;
        public InputAction @Exit => m_Wrapper.m_PlayerControls_Exit;
        public InputAction @Start => m_Wrapper.m_PlayerControls_Start;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Push.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPush;
                @Push.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPush;
                @Push.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPush;
                @Drop.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDrop;
                @Action_X.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_X;
                @Action_X.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_X;
                @Action_X.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_X;
                @Action_Y.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_Y;
                @Action_Y.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_Y;
                @Action_Y.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_Y;
                @Action_B.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_B;
                @Action_B.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_B;
                @Action_B.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction_B;
                @RightJoystickRotation.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightJoystickRotation;
                @RightJoystickRotation.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightJoystickRotation;
                @RightJoystickRotation.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightJoystickRotation;
                @Exit.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                @Start.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Push.started += instance.OnPush;
                @Push.performed += instance.OnPush;
                @Push.canceled += instance.OnPush;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Action_X.started += instance.OnAction_X;
                @Action_X.performed += instance.OnAction_X;
                @Action_X.canceled += instance.OnAction_X;
                @Action_Y.started += instance.OnAction_Y;
                @Action_Y.performed += instance.OnAction_Y;
                @Action_Y.canceled += instance.OnAction_Y;
                @Action_B.started += instance.OnAction_B;
                @Action_B.performed += instance.OnAction_B;
                @Action_B.canceled += instance.OnAction_B;
                @RightJoystickRotation.started += instance.OnRightJoystickRotation;
                @RightJoystickRotation.performed += instance.OnRightJoystickRotation;
                @RightJoystickRotation.canceled += instance.OnRightJoystickRotation;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPush(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnAction_X(InputAction.CallbackContext context);
        void OnAction_Y(InputAction.CallbackContext context);
        void OnAction_B(InputAction.CallbackContext context);
        void OnRightJoystickRotation(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
}
