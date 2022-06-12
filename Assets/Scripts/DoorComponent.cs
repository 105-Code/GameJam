using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent: MonoBehaviour
{
    private InteractComponent _interact;

    private void Start()
    {
        this._interact = this.GetComponentInChildren<InteractComponent>();
        this._interact.action += this.openDoor;
        this._interact.Enable = false;
    }

    public void openDoor(GameObject door)
    {
        Destroy(door);
    }

}
