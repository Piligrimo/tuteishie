using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;
    Vector2 prevSpeed;
    bool bubbled;
    public GameObject Core;
    Oxygen oxygen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        oxygen = Core.GetComponent<Oxygen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbled)
           oxygen.amount -= Time.deltaTime*5;
        Vector2 speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (speed.magnitude > 0 && !bubbled)
            rb.velocity = speed.normalized * 3;
        if (prevSpeed.magnitude > 0 && speed.magnitude == 0)
            rb.velocity = Vector2.zero;
        an.SetBool("swim", speed.magnitude > 0);
        
        if (Input.GetButtonDown("Jump"))
        {
            bubbled = true;
            an.SetBool("bubble", true);
            rb.velocity = Vector2.zero;
        }
        if (Input.GetButtonUp("Jump"))
        {
            bubbled = false;
            an.SetBool("bubble", false);
        }
        oxygen.amount -= Time.deltaTime * 0.1f;
        
        prevSpeed = speed;
    }
    
}
