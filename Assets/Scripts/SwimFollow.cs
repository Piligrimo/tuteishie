using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimFollow : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 up, down;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        up = new Vector2(-speed, 0.5f * Mathf.Abs(speed));
        down = new Vector2(-speed, -0.5f * Mathf.Abs(speed));
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            if (player.transform.position.y > transform.position.y)
                rb.velocity = up;
            else
                rb.velocity = down;
        }
        else
        rb.velocity = new Vector2(-speed, 0);
    }
}
