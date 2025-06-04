using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PlayerLocomotion : MonoBehaviour
{
    [Header("References")]
    public CharacterController characterController;
    public Transform headTransform;

    [Header("Movement")]
    public float moveSpeed = 1.5f;
    public float rotationSpeed = 60f;

    private XRIDefaultInputActions inputActions;

    private Vector2 moveInput;
    private Vector2 turnInput;

    private void Awake()
    {
        inputActions = new XRIDefaultInputActions();

        inputActions.XRILeftLocomotion.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.XRILeftLocomotion.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.XRIRightLocomotion.Turn.performed += ctx => turnInput = ctx.ReadValue<Vector2>();
        inputActions.XRIRightLocomotion.Turn.canceled += ctx => turnInput = Vector2.zero;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        // Mover en la dirección que mira el jugador
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 headYaw = new Vector3(headTransform.forward.x, 0, headTransform.forward.z).normalized;
        Quaternion rotation = Quaternion.LookRotation(headYaw);
        Vector3 movement = rotation * direction * moveSpeed * Time.deltaTime;

        characterController.Move(movement);
    }

    private void HandleRotation()
    {
        float turnAmount = turnInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, turnAmount);
    }
}
