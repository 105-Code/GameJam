using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInfoEvent : EventHandler
{

    private void Awake()
    {
        this._close_dialog = false;
        
    }

    public override bool triggerEvent(string event_code)
    {
        if (event_code == "complete")
        {
            this.GetComponent<InteractComponent>().Enable = false;
            return true;
        }

        return false;
    }
}

