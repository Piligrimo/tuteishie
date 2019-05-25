using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    GameObject player;
    bool spedUp=false;
    public float quoph;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        spedUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<8 && Mathf.Abs(player.transform.position.y - transform.position.y) < 1 && !spedUp)
        {
            spedUp = true;
            GetComponent<Rigidbody2D>().velocity *= quoph;
        }
    }
}
