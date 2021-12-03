using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

    public float moveSpeed = 5;

    bool moveable = true;
    bool hasFlameTorch = false;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (!moveable)
            return;
        //basic movement script
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void stopPlayerMovement()
    {
        moveable = false;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
    }

    public void startPlayerMovement()
    {
        moveable = true;
    }

    private void FixedUpdate()
    {
        if (!moveable)
            return;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.transform.parent.name == "Ice")
        {
            if(hasFlameTorch)
            {
                collision.gameObject.SetActive(false);
            }
            // collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Vector2 p = rb.position;
            Vector2 direction = (Vector2) collision.gameObject.transform.position - p;
            collision.gameObject.GetComponent<Blocks>().moveIce(direction);
            return;
        }        

        if (collision.gameObject.transform.parent.name == "PF Grass A")
        {
            Debug.Log("OnCollisionEnter2DFlameTorch");
            hasFlameTorch = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.transform.parent.parent == null)
        {
            return;
        }

        if (collision.gameObject.transform.parent.parent.name == "Word")
        {
            // collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Vector2 p = rb.position;
            Vector2 direction = (Vector2)collision.gameObject.transform.position - p;
            collision.gameObject.GetComponent<Blocks>().setupWordMovement(direction);
            return;
        }

    }
}
