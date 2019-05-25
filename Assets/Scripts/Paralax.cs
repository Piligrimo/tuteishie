using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public GameObject[] objects;
    int count;
    public float width, speed,offset;

    // Start is called before the first frame update
    void Start()
    {
        count = objects.Length;
        foreach (GameObject go in objects)
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<count;i++)
        {
            if (objects[i].transform.position.x < -width-offset)
                objects[i].transform.position = new Vector3(width, 0, 0) + objects[(i + count - 1) % count].transform.position;
        }
    }
}
