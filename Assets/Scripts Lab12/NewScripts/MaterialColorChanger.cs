using UnityEngine;
using UnityEngine.InputSystem;

public class MaterialColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;

    private XRIDefaultInputActions inputActions;

    private void Awake()
    {
        inputActions = new XRIDefaultInputActions();

        //inputActions.XRILeftHand.Activate.performed += OnXButtonPressed;
        //inputActions.XRIRightHand.Activate.performed += OnAButtonPressed;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnXButtonPressed(InputAction.CallbackContext ctx)
    {
        SetRedChannel(0f);
    }

    private void OnAButtonPressed(InputAction.CallbackContext ctx)
    {
        SetRedChannel(1f); // 1.0 en Color equivale a 255
    }

    public void SetRedChannel(float r)
    {
        if (targetRenderer == null) return;

        Color color = targetRenderer.material.color;
        color.r = r;
        targetRenderer.material.color = color;

        Debug.Log($"Color R cambiado a: {r}");
    }
}
