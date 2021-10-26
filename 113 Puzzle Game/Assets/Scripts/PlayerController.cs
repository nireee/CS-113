using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    
    public Transform follow_point;
    public GameObject player;
    public Transform portal_target;
    public Transform portal_start;
    public Transform portal_end;
    public float moveSpeed = 2;
    public bool MeetNPC;
    public bool portal_state;
    public GameObject NPC;


    public bool hasHeatStone;

    // Start is called before the first frame update
    void Start()
    {
        hasHeatStone = false;
        MeetNPC = false;
        portal_state = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetKey(KeyCode.E) && MeetNPC)
        {
            //provide a logic question to the player and give hint
            MeetNPC = false;
            NPC.GetComponent<Collider2D>().enabled = false;
        }

        ChangePortalState();

    }

    private void ChangePortalState()
    {
        if (portal_state)
        {
            portal_target.position = new Vector2(portal_start.position.x, portal_start.position.y);
        }
        else if (!portal_state)
        {
            portal_target.position = new Vector2(portal_end.position.x, portal_end.position.y);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            MeetNPC = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            Debug.Log("You Win!");
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.tag == "Portal")
        {
            player.transform.position = new Vector2(portal_target.position.x, portal_target.position.y);
            portal_state = !portal_state;
        }
    }
    

}
