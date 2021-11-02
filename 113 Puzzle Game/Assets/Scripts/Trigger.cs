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
        door.GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.GetComponent<Collider2D>().enabled = true;
    }
}
