using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class MaterialColorChanger : MonoBehaviour
{
    public Renderer targetRenderer;

    private XRInputActions inputActions;
    private float redValue = 1f; // Normalizado (0 a 1)

    private void Awake()
    {
        inputActions = new XRInputActions();
    }

    private void OnEnable()
    {
        inputActions.XRControls.Enable();

        inputActions.XRControls.Joystick.performed += OnRightJoystick;
        inputActions.XRControls.LeftJoystick.performed += OnLeftJoystick;
    }

    private void OnDisable()
    {
        inputActions.XRControls.Joystick.performed -= OnRightJoystick;
        inputActions.XRControls.LeftJoystick.performed -= OnLeftJoystick;

        inputActions.XRControls.Disable();
    }

    private void OnRightJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 axis = ctx.ReadValue<Vector2>();
        if (axis.x < -0.1f) // desliza a la izquierda
        {
            redValue = Mathf.Clamp01(redValue - 0.01f);
            ApplyColor();
        }
    }

    private void OnLeftJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 axis = ctx.ReadValue<Vector2>();
        if (axis.x > 0.1f) // desliza a la derecha
        {
            redValue = Mathf.Clamp01(redValue + 0.01f);
            ApplyColor();
        }
    }

    private void ApplyColor()
    {
        if (targetRenderer != null && targetRenderer.material.HasProperty("_Color"))
        {
            Color current = targetRenderer.material.color;
            current.r = redValue;
            targetRenderer.material.color = current;
        }
    }
}
