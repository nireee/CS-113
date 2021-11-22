using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Puzzle2PlayerController : MonoBehaviour
{

    public Transform follow_point;
    public GameObject player;
    public Transform portal_1;
    public Transform portal_2;
    public bool MeetNPC;
    public GameObject NPC;
    public GameObject intro;
    public GameObject TextWindow;
    public bool AnsCorrect;
    public TextMeshProUGUI textDisplay;
    public GameObject hintarrow;

    public bool transported = false;
    public Animator animator;
    Vector2 movement;
    public float moveSpeed = 5;
    public Rigidbody2D rb;

    bool moveable = true;
    private float LoadingStart;
    private float Loadtime = 2f;

    public bool hasHeatStone;

    // Start is called before the first frame update
    void Start()
    {
        hasHeatStone = false;
        MeetNPC = false;
        LoadingStart = Time.fixedTime;
        
    }
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
        if(intro.activeSelf && LoadingStart + Loadtime < Time.fixedTime)
        {
            intro.SetActive(false);
        }


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
        if (collision.gameObject.tag == "NPC")
        {
            TextWindow.SetActive(true);
            moveable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("You Win!");
            moveable = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == "Portal" && transported == false)
        {
            player.transform.position = new Vector3(portal_2.position.x, portal_2.position.y, -8.5689f);
            transported = true;
            
        }
    }


    public void Choice1()
    {
        Debug.Log("Choice 1");
        AnsCorrect = true;
        TextWindow.SetActive(false);
        hintarrow.SetActive(true);
        NPC.GetComponent<Collider2D>().enabled = false;
        moveable = true;
    }

    public void Choice2()
    {
        Debug.Log("Choice 2");
        AnsCorrect = false;
        TextWindow.SetActive(false);
        NPC.GetComponent<Collider2D>().enabled = false;
        moveable = true;
    }

}