using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class VRInputManager : MonoBehaviour
{
    public UnityEvent onTriggerPressedLeft;
    public UnityEvent onTriggerPressedRight;
    public UnityEvent onGripPressedLeft;
    public UnityEvent onGripPressedRight;
    public UnityEvent onPrimaryButtonPressed; // A/X
    public UnityEvent onSecondaryButtonPressed; // B/Y
    public UnityEvent onXLeftHeld;
    public UnityEvent onXRightHeld;
    private InputDevice leftHand;
    private InputDevice rightHand;

    void Start()
    {
        InitControllers();
    }

    void InitControllers()
    {
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);
        if (leftHandDevices.Count > 0) leftHand = leftHandDevices[0];

        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count > 0) rightHand = rightHandDevices[0];
    }

    void Update()
    {
        if (!leftHand.isValid || !rightHand.isValid) InitControllers();

        // Gatillos (Trigger)
        if (rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerRight) && triggerRight)
            onTriggerPressedRight.Invoke();

        if (leftHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerLeft) && triggerLeft)
            onTriggerPressedLeft.Invoke();

        // Agarre (Grip)
        if (rightHand.TryGetFeatureValue(CommonUsages.gripButton, out bool gripRight) && gripRight)
            onGripPressedRight.Invoke();

        if (leftHand.TryGetFeatureValue(CommonUsages.gripButton, out bool gripLeft) && gripLeft)
            onGripPressedLeft.Invoke();

        // Botones A/X
        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool aPressed) && aPressed)
            onPrimaryButtonPressed.Invoke();

        if (leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool bPressed) && bPressed)
            onSecondaryButtonPressed.Invoke();

        if (leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool xLeft) && xLeft)
            onXLeftHeld.Invoke();

        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool xRight) && xRight)
            onXRightHeld.Invoke();
    }
}