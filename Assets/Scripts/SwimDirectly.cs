using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimDirectly : MonoBehaviour
{
    GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 vel = (player.transform.position - transform.position).normalized * speed;
        GetComponent<Rigidbody2D>().velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
