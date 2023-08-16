using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.hoverEntered.AddListener(ClickButton);
        interactable.hoverExited.AddListener(ReleaseButton);
    }

    private void ClickButton(HoverEnterEventArgs args)
    {
        gameObject.AddComponent<ButtonPress>();

        BoxCollider bc = GameObject.Find("RightHand Controller").AddComponent<BoxCollider>();
        bc.isTrigger = true;
        bc.center = new Vector3(-0.04463115f, 0.01983248f, 2.092196f);
        bc.size = new Vector3(0.07437587f, 0.1090416f, 4.209292f);
    }

    private void ReleaseButton(HoverExitEventArgs args)
    {
        Destroy(GetComponent<ButtonPress>());
        Destroy(GameObject.Find("RightHand Controller").GetComponent<BoxCollider>());
    }
}
