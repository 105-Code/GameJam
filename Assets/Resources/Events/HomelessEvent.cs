using UnityEngine;

public class HomelessEvent : EventHandler
{

    public GameObject bottlePrefab;

    private DialogComponent _dialog_component;

    private void Awake()
    {
        this._close_dialog = false;
        this._dialog_component = this.GetComponent<DialogComponent>();
    }

    public override bool triggerEvent(string event_code)
    {
        if (event_code == "homeless_quest")
        {
            return this.homelessQuest();
        }

        if (event_code == "homeless_quest_complete")
        {
            return this.homelessQuestComplete();
        }

        return false;
    }

    private bool homelessQuest()
    {
        Debug.Log("Misión Activada");
        Instantiate(this.bottlePrefab, new Vector3(1,2,30), Quaternion.identity);
        Instantiate(this.bottlePrefab, new Vector3(1, 2, 10), Quaternion.identity);


        return true;
    }

    private bool homelessQuestComplete()
    {
        Debug.Log("Misión Completada!");
        return true;
    }
}
