using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger:OnCollisionEnter2D");
        gameObject.GetComponent<AudioSource>().Play();
        door.GetComponent<DoorController>().openDoor();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger:OnCollisionExit2D");
        door.GetComponent<DoorController>().closeDoor();
    }
}
