using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : EventHandler
{

    public LevelController levelController;

    private void Awake()
    {
        this._close_dialog = false;

    }

    public override bool triggerEvent(string event_code)
    {
        if (event_code == "boss_complete")
        {
            return this.bossComplete();
        }

        return false;
    }

    private bool bossComplete()
    {
        Debug.Log("Misión Completada!");
        this.GetComponent<InteractComponent>().Enable = false;
        this.levelController.IsComplete = true;
        return true;
    }

}

