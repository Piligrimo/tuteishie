using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimStraight : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed-Random.value*speed*0.3f, 0);
    }
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed - Random.value * speed * 0.3f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
