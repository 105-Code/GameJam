using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(GoToPoor());
    }


    IEnumerator GoToPoor()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("PoorSection");
    }
}
