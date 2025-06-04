using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class OculusInputHandler : MonoBehaviour
{
    private XRInputActions inputActions;

    public bool primaryButtonPressed;
    public bool secondaryButtonPressed;
    public bool gripButtonPressed;
    public bool triggerButtonPressed;
    public bool menuButtonPressed;

    public float gripValue;
    public float triggerValue;
    public Vector2 joystick;
    public Vector2 leftJoystick;
    private void Awake()
    {
        inputActions = new XRInputActions();

        inputActions.XRControls.PrimaryButton.performed += OnPrimaryButtonPressed;
        inputActions.XRControls.PrimaryButton.canceled += OnPrimaryButtonReleased;

        inputActions.XRControls.SecondaryButton.performed += OnSecondaryButtonPressed;
        inputActions.XRControls.SecondaryButton.canceled += OnSecondaryButtonReleased;

        inputActions.XRControls.GripButton.performed += OnGripButtonPressed;
        inputActions.XRControls.GripButton.canceled += OnGripButtonReleased;

        inputActions.XRControls.TriggerButton.performed += OnTriggerButtonPressed;
        inputActions.XRControls.TriggerButton.canceled += OnTriggerButtonReleased;

        inputActions.XRControls.MenuButton.performed += OnMenuButtonPressed;
        inputActions.XRControls.MenuButton.canceled += OnMenuButtonReleased;

        inputActions.XRControls.Joystick.performed += ctx => joystick = ctx.ReadValue<Vector2>();
        inputActions.XRControls.Joystick.canceled += ctx => joystick = Vector2.zero;

        inputActions.XRControls.GripValue.performed += ctx => gripValue = ctx.ReadValue<float>();
        inputActions.XRControls.GripValue.canceled += ctx => gripValue = 0f;

        inputActions.XRControls.TriggerValue.performed += ctx => triggerValue = ctx.ReadValue<float>();
        inputActions.XRControls.TriggerValue.canceled += ctx => triggerValue = 0f;

        inputActions.XRControls.LeftJoystick.performed += ctx => leftJoystick = ctx.ReadValue<Vector2>();
        inputActions.XRControls.LeftJoystick.canceled += ctx => leftJoystick = Vector2.zero;
    }

    private void OnEnable()
    {
        inputActions.XRControls.Enable();
    }

    private void OnDisable()
    {
        inputActions.XRControls.Disable();
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext ctx) => primaryButtonPressed = true;
    private void OnPrimaryButtonReleased(InputAction.CallbackContext ctx) => primaryButtonPressed = false;

    private void OnSecondaryButtonPressed(InputAction.CallbackContext ctx) => secondaryButtonPressed = true;
    private void OnSecondaryButtonReleased(InputAction.CallbackContext ctx) => secondaryButtonPressed = false;

    private void OnGripButtonPressed(InputAction.CallbackContext ctx) => gripButtonPressed = true;
    private void OnGripButtonReleased(InputAction.CallbackContext ctx) => gripButtonPressed = false;

    private void OnTriggerButtonPressed(InputAction.CallbackContext ctx) => triggerButtonPressed = true;
    private void OnTriggerButtonReleased(InputAction.CallbackContext ctx) => triggerButtonPressed = false;

    private void OnMenuButtonPressed(InputAction.CallbackContext ctx) => menuButtonPressed = true;
    private void OnMenuButtonReleased(InputAction.CallbackContext ctx) => menuButtonPressed = false;
}