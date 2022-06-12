using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject panelStart, panelEnd;

    void Awake()
    {
        panelEnd.SetActive(false);
        panelStart.SetActive(true);
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(15f);
        panelEnd.SetActive(true);
    }
}
