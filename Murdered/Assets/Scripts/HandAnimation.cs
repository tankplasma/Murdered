using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HandAnimation : MonoBehaviour
{

    public XRNode inputSource;

    [SerializeField]
    private Animator annimation;

    private float trigger;
    private float grip;

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.trigger, out trigger);
        device.TryGetFeatureValue(CommonUsages.grip, out grip);
        annimation = GetComponentInChildren<Animator>();

        annimation.SetLayerWeight(1, trigger-grip);       
        annimation.SetLayerWeight(2, grip-trigger);
        annimation.SetFloat("Trigger", trigger);
        annimation.SetFloat("Grip", grip);
    }
}
