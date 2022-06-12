using UnityEngine;

public class HomelessEvent : EventHandler
{

    public GameObject bottlePrefab;
    public Vector3 bottle1_position;
    public Vector3 bottle2_position;
    public TextAsset JSONComplete;
    public LevelController levelController;

    private short _bottles;
    private DialogComponent _dialog_component;

    private void Awake()
    {
        this._close_dialog = false;
        this._bottles = 0;
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
        GameObject bottle1 = Instantiate(this.bottlePrefab, this.bottle1_position, Quaternion.identity);
        GameObject bottle2 = Instantiate(this.bottlePrefab, this.bottle2_position, Quaternion.identity);
        this.GetComponent<InteractComponent>().Enable = false;
        bottle1.GetComponent<InteractComponent>().action += this.findBottle;
        bottle2.GetComponent<InteractComponent>().action += this.findBottle;
        return true;
    }

    private void findBottle(GameObject bottle)
    {
        this._bottles++;
        Debug.Log("Botella encontrada");
        Debug.Log(this._bottles);
        Destroy(bottle);
        if(this._bottles == 2)
        {
            Debug.Log("Reiniciando NPC");
            this._dialog_component.JSON = this.JSONComplete;
            this._dialog_component.loadFile();
            this.GetComponent<InteractComponent>().Enable = true;
        }
    }

    private bool homelessQuestComplete()
    {
        Debug.Log("Misión Completada!");
        this.GetComponent<InteractComponent>().Enable = false;
        this.levelController.IsComplete = true;
        return true;
    }
}
