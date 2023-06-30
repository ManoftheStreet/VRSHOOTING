using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptic : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;

    private void OnEnable()
    {
        grabInteractable.activated.AddListener(SendHapticFeedback);
    }

    private void OnDisable()
    {
        grabInteractable.activated.AddListener(SendHapticFeedback);
    }
    private void SendHapticFeedback(ActivateEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(0.7f, 0.1f);
    }
}
