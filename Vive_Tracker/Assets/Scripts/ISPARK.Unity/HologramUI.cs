using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramUI : MonoBehaviour
{
    public GameObject hologramUIPopUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("충돌");
            hologramUIPopUp.SetActive(true);
        }
    }
}
