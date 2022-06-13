using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SadGuyEvent : EventHandler
{
    public InteractComponent draingTrigger;
    private DialogComponent _dialog_component;
    public TextAsset JSONComplete;
    public LevelController levelController;
    public GameObject bubble;
    private GameObject _active_bubble;

    private void Awake()
    {
        this._close_dialog = false;
        this._dialog_component = this.GetComponent<DialogComponent>();

    }

    public override bool triggerEvent(string event_code)
    {
        if (event_code == "sad_guy_quest")
        {
            return this.SadGuyQuest();
        }

        if (event_code == "sad_guy_complete")
        {
            return this.SadGuyComplete();
        }

        return false;
    }

    private bool SadGuyQuest()
    {
        this.GetComponent<InteractComponent>().Enable = false;
        this.draingTrigger.transform.gameObject.SetActive(true);
        this.draingTrigger.action += this.findDrain;

        return true;
    }

    private void findDrain(GameObject drain)
    {
        this.draingTrigger.transform.gameObject.SetActive(false);
        
        this._dialog_component.JSON = this.JSONComplete;
        this._dialog_component.loadFile();
        this.GetComponent<InteractComponent>().Enable = true;
        Vector3 position = this.draingTrigger.transform.position + new Vector3(3,4,-2);

        this._active_bubble = Instantiate(this.bubble, position, Quaternion.identity);
        this._active_bubble.GetComponentInChildren<TextMeshProUGUI>().text = "Creo que por aquí se puede salir.";
        StartCoroutine(this.hideBubble());

    }

    IEnumerator hideBubble()
    {
        yield return new WaitForSeconds(3);
        Destroy(this._active_bubble);
    }

    private bool SadGuyComplete()
    {
        this.GetComponent<InteractComponent>().Enable = false;
        this.levelController.IsComplete = true;
        return true;
    }

}

