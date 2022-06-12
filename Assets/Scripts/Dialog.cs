using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog {

    public int id;
    public string text;
    public int next;
    public Dialog[] options;
    public string event_code;
    public bool have_options;
    public bool final;
    public bool have_event;
}
