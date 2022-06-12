using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventHandler: MonoBehaviour
{

    protected bool _close_dialog;

    public abstract bool triggerEvent(string event_code);

    public bool keepCloseDialog()
    {
        return this._close_dialog;
    }

}
