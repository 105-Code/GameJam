using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameObject panelStart, panelEnd, textEnd;

    void Awake()
    {
        panelEnd.SetActive(false);
        textEnd.SetActive(false);
        panelStart.SetActive(true);
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(15f);
        panelEnd.SetActive(true);
        yield return new WaitForSeconds(4f);
        textEnd.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}