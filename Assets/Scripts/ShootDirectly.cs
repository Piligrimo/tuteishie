using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDirectly : MonoBehaviour
{
    public GameObject fireball, nose;
    GameObject player;
    float lastShot;
    public float cooldown = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 15 && player.transform.position.x < transform.position.x && Time.time - lastShot > cooldown)
        {
            Instantiate(fireball, nose.transform.position, Quaternion.Euler(0, 0, 0));
            lastShot = Time.time;
        }
    }
}
