using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private string doorOpenedPath = "TX Door_open";
    private string doorClosedPath = "TX Door_close";
    private Sprite doorOpenedSprite;
    private Sprite doorClosedSprite;
    bool is_open = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        doorOpenedSprite = Resources.Load<Sprite>(doorOpenedPath);
        doorClosedSprite = Resources.Load<Sprite>(doorClosedPath);
        closeDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor()
    {
        is_open = true;
        boxCollider2D.enabled = false;
        spriteRenderer.sprite = doorOpenedSprite;
        gameObject.GetComponent<AudioSource>().Play();

    }
    public void closeDoor()
    {
        is_open = false;
        boxCollider2D.enabled = true;
        spriteRenderer.sprite = doorClosedSprite;
    }
}
