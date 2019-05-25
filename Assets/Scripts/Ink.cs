using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    GameObject spot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Spot").GetComponent<InkSpot>().dirtness=7;
        }
            
    }
    private void Update()
    {
    }
}
