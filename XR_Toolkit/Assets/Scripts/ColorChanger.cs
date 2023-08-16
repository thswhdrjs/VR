using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material grey;
    public Material green;

    private MeshRenderer meshRenderer;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetGreen);
        grabInteractable.selectExited.AddListener(SetGrey);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(SetGreen);
        grabInteractable.selectExited.RemoveListener(SetGrey);
    }

    private void SetGreen(SelectEnterEventArgs args)
    {
        meshRenderer.material = green;
    }

    private void SetGrey(SelectExitEventArgs args)
    {
        meshRenderer.material = grey;
    }
}
