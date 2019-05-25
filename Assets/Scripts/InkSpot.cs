using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpot : MonoBehaviour
{
    SpriteRenderer sr;
    public float dirtness = 10;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dirtness > 0)
        {
            dirtness -= Time.deltaTime;
            if (dirtness > 5)
                {
                    sr.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    sr.color = new Color(1, 1, 1, dirtness / 5f);
                }
        }
    }
}
