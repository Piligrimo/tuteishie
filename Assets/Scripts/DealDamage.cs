using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float amount;
    Oxygen oxygen;
    private void Start()
    {
        oxygen = GameObject.FindGameObjectWithTag("Core").GetComponent<Oxygen>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oxygen.amount -= amount;
            if (oxygen.amount > 100)
            {
                oxygen.amount = 100;
                gameObject.GetComponent<EnemyHealth>().amount=0;
            }
        }
    }

}
