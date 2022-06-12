using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    public GameObject interactPrefab;
    public Vector3 offset;
    public Vector3 size;
    public Vector3 rotation;
    public Action<GameObject> action;

    public bool Enable{
        set { 
            this._enable = value;
            if (!value)
            {
                this.destroyInteractObject();
            }
        }    
    }

    private bool _enable;
    private GameObject _interact_active;

    private void Awake()
    {
        this._enable = true;
    }

    private void Update()
    {
        // esta activo
        if (!this._enable)
        {
            return;
        }

        // tiene el objecto interact creado(Esta cerca de este objeto)
        if (this._interact_active == null)
        {
            return;
        }

        // tiene una acción adjunta
        if (this.action == null)
        {
            return;
        }

        // presionó la tecla de interacción
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        

        // ejecuto la acción
        this.action(this.transform.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Alguien cerca");
        if (!this._enable)
        {
            return;
        }

        this._interact_active = Instantiate(this.interactPrefab,this.transform);
        this._interact_active.transform.localPosition= this.offset;
        this._interact_active.transform.localScale = this.size;
        this._interact_active.transform.Rotate(this.rotation);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" Se alejó");
        this.destroyInteractObject();
    }

    private void destroyInteractObject()
    {
        if (this._interact_active != null)
        {
            Destroy(this._interact_active);
        }
        this._interact_active = null;
    }
}
