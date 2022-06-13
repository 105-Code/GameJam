using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string nextSceneName;
    public bool IsComplete
    {
        get { return this._is_complete; }
        set
        {
            this._is_complete = value;
            if (value)
            {
                this.doorInteractComponent.Enable = true;
            }
        }
    }
    private bool _is_complete;
    public InteractComponent doorInteractComponent;

    void Start()
    {
        this._is_complete = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }


    public void changeScene()
    {
        if (!this._is_complete)
        {
            throw new System.Exception("No se ha especificado la escena");
        }
        SceneManager.LoadScene(this.nextSceneName);
    }
}
