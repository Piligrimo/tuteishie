using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    GameObject gameObject;
    public EnemyHealth health;
    public int difficulty;
    public Enemy(GameObject go)
    {
        gameObject = go;
        health = go.GetComponent<EnemyHealth>();
        health.self = this;
        difficulty = health.difficulty;
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
    public void Born()
    {
        gameObject.SetActive(true);
        health.amount = health.maximum;
        switch (health.spawnType)
        {
            case EnemyHealth.SpawnType.behind:
                gameObject.transform.position = new Vector3(-13, Random.value * 9 - 3, 0);
                break;
            case EnemyHealth.SpawnType.fixedPoint:
                gameObject.transform.position = new Vector3(13, - 3, 0);
                break;
            default:
                gameObject.transform.position = new Vector3(13, Random.value * 9 - 3, 0);
                break;

        }
    }
}
