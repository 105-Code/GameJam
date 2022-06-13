using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 9f;
    private Rigidbody _rigibody;
    private bool _can_move;
    public AudioSource steps;

    public Animator animator;
    private bool m_FacingLeft = true; 

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
            this.horizontalAnimation(xMove);
            if(zMove != 0 || xMove != 0)
            {
                this.animator.SetFloat("Speed", 1);
                if (!this.steps.isPlaying)
                {
                    this.steps.Play();
                }
            }
            else
            {
                this.animator.SetFloat("Speed", 0);
            }

            this._rigibody.velocity = new Vector3(xMove, 0, zMove) * speed;
        }

    }

    private void horizontalAnimation(float xMove)
    {
        if (xMove < 0 && !this.m_FacingLeft)
        {
            this.flip();

            return;
        }

        if (xMove > 0 && this.m_FacingLeft)
        {
            this.flip();
           
            return;
        }
    }

    private void flip()
    {
        // Switch the way the player is labelled as facing.
        this.m_FacingLeft = !this.m_FacingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
