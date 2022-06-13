using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class DialogComponent : MonoBehaviour
{
    public TextAsset JSON;
    public EventHandler eventHandler;
    public DialogManager dialogManager;
    public Sprite profile;

    private int _index;
    private string _actor;
    private Dictionary<int, Dialog> _dialogs;
    private bool _dialog_started;
    private Dialog _current_dialog;
    private bool _can_start;

    private void Awake()
    {
       
        this.loadFile();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._can_start)
        {
            return;
        }
  
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        if (!this._dialog_started)
        {
            this.dialogManager.Profile = this.profile;
            this.dialogManager.gameObject.SetActive(true);
            this._dialog_started = true;
        }

        if (this.dialogManager.waiting)
        {
            return;
        }
        this._dialogs.TryGetValue(this._index, out this._current_dialog);
        this.showCurrentDialog();
        this.setNextDialog();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Ya no puedo Hablar");
        this._can_start = false;
        Debug.Log(this._can_start.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Puedo Hablar");
        this._can_start = true;
        Debug.Log(this._can_start.ToString());
    }

    private void showCurrentDialog()
    {
        if (this._current_dialog != null)
        {
            if (this._current_dialog.have_event)
            {
                this.eventHandler.triggerEvent(this._current_dialog.event_code);
            }

            this.dialogManager.showDialog(this._current_dialog, this.onClickOption);
            this.setNextDialog();
        }
    }

    private void onClickOption(Dialog option)
    {
       
        if (option.have_event)
        {
            this.eventHandler.triggerEvent(option.event_code);
        }
        this._index = option.next;
        this._dialogs.TryGetValue(this._index, out this._current_dialog);
        this.showCurrentDialog();
        this.setNextDialog();
    }

    private void setNextDialog()
    {
        if (this._current_dialog.have_options)
        {
            return;
        }

        if (this._current_dialog.final)
        {
            this.dialogManager.gameObject.SetActive(false);
            this._dialog_started = false;
            return;
        }

        this._index = this._current_dialog.next;
    }

    public bool loadFile()
    {
        this._index = 0;
        this._dialog_started = false;
        this._dialogs = new Dictionary<int, Dialog>();
        this._can_start = false;
        ActorJSON actor = JsonUtility.FromJson<ActorJSON>(this.JSON.text);
        
        this._actor = actor.name;

        foreach(Dialog dialog in actor.dialogs)
        {
            this._dialogs.Add(dialog.id, dialog);
            
            if(this._index > dialog.id)
            {
                this._index = dialog.id;
            }
        }

        return true;
    }

    // esta clse de usa solo para cargar la información del JSON
    [System.Serializable]
    private class ActorJSON
    {
        public string name;
        public Dialog[] dialogs;

    }

}
