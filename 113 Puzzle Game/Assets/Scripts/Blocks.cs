using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    GameObject player;
    bool moving = false;
    Vector2 startPos;
    Vector2 destPos;
    float duration = .0f;
    float iceSpeed = 10.0f;
    
    public Rigidbody2D rb;

    Vector2[] directions = { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            moveWord();
        }
    }

    public void moveIce(Vector2 direction)
    {
        Vector2 movement = directions[(((int)Mathf.Round(Mathf.Atan2(direction.y, direction.x) / (2 * Mathf.PI / 4))) + 4) % 4];
        rb.velocity = movement * iceSpeed;
    }

    public void setupWordMovement(Vector2 direction)
    {
        Collider2D[] res = new Collider2D[5];
        if(rb.OverlapCollider(new ContactFilter2D(), res) > 1)
            return;
        Vector2 movement = directions[(((int)Mathf.Round(Mathf.Atan2(direction.y, direction.x) / (2 * Mathf.PI / 4))) + 4) % 4];
        moving = true;
        startPos = transform.position;
        destPos = startPos + movement;
        player.GetComponent<PlayerController>().stopPlayerMovement();
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void moveWord()
    {
        rb.MovePosition(Vector2.Lerp(startPos, destPos, duration));
        duration += Time.deltaTime;
        if (duration >= 1.0f)
        {
            transform.position = destPos;
            moving = false;
            duration = 0.0f;
            player.GetComponent<PlayerController>().startPlayerMovement();
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Block Collision");
        /*if (collision.gameObject.name == "Player")
        {
            return;
        }
        Debug.Log("Reset Velocity");
        rb.velocity = Vector3.zero;
        rb.
    }*/

        //block as wall


        //block as word blocks




    }
