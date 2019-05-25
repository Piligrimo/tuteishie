using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rigidbody.velocity = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (rigidbody.velocity.magnitude>0)
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 180+Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) * 180 / Mathf.PI);

    }
}
