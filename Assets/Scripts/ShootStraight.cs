using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStraight : MonoBehaviour
{
    public GameObject fireball,nose,head;
    public bool animated;
    GameObject player;
    public Sprite fire, normal;
    SpriteRenderer sr;
    float lastShot;
    public float cooldown=2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastShot = Time.time;
        if (animated)
        sr = head.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<15 && Mathf.Abs(player.transform.position.y - transform.position.y) < 1 && player.transform.position.x < transform.position.x && Time.time - lastShot > cooldown)
        {
            Instantiate(fireball, nose.transform.position,Quaternion.Euler(0,0,0));
            lastShot = Time.time;
            if (animated)
            sr.sprite = fire;
        }
        if (animated)
        if (sr.sprite == fire && Time.time-lastShot>0.1f*cooldown)
        {
            sr.sprite = normal;
        }
    }
}
