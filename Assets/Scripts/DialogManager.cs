using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject textHolder;
    public GameObject optionsHolder;
    public GameObject optionPrefab;
    public bool waiting;

    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        Debug.Log("Enable");
        this.waiting = false;
        this._text = this.textHolder.GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
        this._text.text = "";
    }

    public void showDialog(Dialog dialog, Action<Dialog> onClickOption)
    {
        this._text.text = dialog.text;
        if (dialog.have_options)
        {
            this.waiting = true;
            foreach (Dialog option in dialog.options)
            {
                GameObject optionObject =Instantiate(this.optionPrefab,this.optionsHolder.transform);
                TextMeshProUGUI text= optionObject.GetComponentInChildren<TextMeshProUGUI>();
                Button button = optionObject.GetComponent<Button>();
                text.text = option.text;
                Debug.Log("Agregando opciones");
                button.onClick.AddListener( () => {
                    Debug.Log("Click Opci�n");
                    this.waiting = false;
                    onClickOption(option);
                    this.optionsHolder.transform.DetachChildren(); // remueve todos los hijos 
                });
            }
        }
    }

}
