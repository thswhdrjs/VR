using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    private GameObject plane;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if (transform.GetChild(0).gameObject.GetComponent<ButtonPress>())
        {
            if (other.gameObject.name == "RightHand Controller")
                plane.SetActive(plane.activeSelf ? false : true);
        }
    }

    private void Start()
    {
        plane = GameObject.Find("Plane");
    }
}
