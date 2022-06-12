using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody _rigibody;
    private bool _can_move;

    public bool CanMove{
        get { return this._can_move; }
        set { this._can_move = value; }
}


    // Start is called before the first frame update
    void Start()
    {
        this._can_move = true;
        this._rigibody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (this._can_move)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            float zMove = Input.GetAxisRaw("Vertical");
            this._rigibody.velocity = new Vector3(xMove, 0, zMove) * speed;
        }

    }

}
