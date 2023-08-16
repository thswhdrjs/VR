using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Excep : MonoBehaviour
{
    public GameObject rigthRay, leftRay;

    public GameObject logoCanvas, titleCanvas, introductionCanvas, characterInfoCanvas, createCharacterCanvas,
                      mainHallIntroCanvas, mainHallInfoCanvas, hologramUICanvas;

    void Start()
    {
        StartCoroutine("BeforeCreateCharacterCoroutine");
    }

    IEnumerator BeforeCreateCharacterCoroutine()
    {
        logoCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        logoCanvas.SetActive(false);

        titleCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        titleCanvas.SetActive(false);

        introductionCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        introductionCanvas.SetActive(false);

        characterInfoCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        characterInfoCanvas.SetActive(false);

        createCharacterCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);

        StopCoroutine("BeforeCreateCharacterCoroutine");

    }
    
    IEnumerator AfterCreateCharacterCoroutine()
    {
        createCharacterCanvas.SetActive(false);

        mainHallIntroCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        mainHallIntroCanvas.SetActive(false);

        yield return new WaitForSeconds(7f);
        mainHallInfoCanvas.SetActive(true);
    }

    public void CreateButtonClick()
    {
        StartCoroutine("AfterCreateCharacterCoroutine");
    }
}
