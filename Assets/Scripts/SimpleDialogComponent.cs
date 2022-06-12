using System.Collections;
using TMPro;
using UnityEngine;


public class SimpleDialogComponent : MonoBehaviour
{
    public TextAsset JSON;
    public GameObject dialogBubble;
    public float bubbleTime;

    private int _index;
    private ActorJSON _actor;
    private TextMeshProUGUI _text;
    private bool _waiting;

    private void Awake()
    {
        this._index = 0;
        this._waiting = false;
        this._text = this.dialogBubble.GetComponentInChildren<TextMeshProUGUI>();
        this.loadFile();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this._waiting) {
            return;
        }
        this._waiting = true;
        this._text.text = this._actor.dialogs[this._index].text;
        this.dialogBubble.SetActive(true);
        StartCoroutine(this.hideBubble());
    }

    IEnumerator hideBubble()
    {
        yield return new WaitForSeconds(this.bubbleTime);
        this.dialogBubble.SetActive(false);
        this._index += 1;
        if (this._index >= this._actor.dialogs.Length)
        {
            this._index = 0;
        }
        this._waiting = false;

    }


    private bool loadFile()
    {
        this._actor = JsonUtility.FromJson<ActorJSON>(this.JSON.text);
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
