using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionComponent: MonoBehaviour
{

    public LevelController levelController;

    private void OnTriggerEnter(Collider other)
    {
        this.levelController.changeScene();
    }

}
