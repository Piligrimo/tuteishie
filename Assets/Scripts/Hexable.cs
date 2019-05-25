using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexable : MonoBehaviour
{
    public GameObject horse;
    public bool bubbled=false;
    public void Hex()
    {
        horse.SetActive(true);
        horse.transform.position = transform.position;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bubbled)
        if (collision.gameObject.tag == "HexProjectile")
            Hex();
    }
}
