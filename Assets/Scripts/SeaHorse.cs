using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaHorse : MonoBehaviour
{
    public GameObject player;
    float duration = 3, purgeTime,speed;
    // Start is called before the first frame update

    private void OnEnable()
    {
        speed = Random.value * 2+1;
        purgeTime = Time.time + duration;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, Random.value*2-1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time>purgeTime)
        {
            player.SetActive(true);
            player.transform.position = transform.position;
            gameObject.SetActive(false);
        }

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    purgeTime = 0;
    //}
}

