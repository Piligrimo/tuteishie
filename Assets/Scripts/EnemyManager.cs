using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text scoreLabel;
    int score;
    float spawnTickLength = 5,currentDifficulty=5;
    List<Enemy> EnemyPool, AliveEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnTick());
        AliveEnemies = new List<Enemy>();
        EnemyPool = new List<Enemy>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Enemy enemy = new Enemy(go);
            EnemyPool.Add(enemy);
            enemy.Die();
        }

    }
    void Spawn(Enemy enemy)
    {
        enemy.Born();
        AliveEnemies.Add(enemy);
        EnemyPool.Remove(enemy);
    }
    public void Kill(Enemy enemy,int reward)
    {
        score += reward;
        scoreLabel.text = score.ToString();
        AliveEnemies.Remove(enemy);
        EnemyPool.Add(enemy);
        enemy.Die();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Spawn(EnemyPool[(int)(EnemyPool.Count * Random.value)]);
            
        }
    }
    IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTickLength);
            var sortedPool = EnemyPool.OrderBy(e => e.difficulty);            
            if (EnemyPool.Count > 0)
                Spawn(sortedPool.ElementAt((int)(Random.value*Mathf.Min(EnemyPool.Count, currentDifficulty))))  ;
            currentDifficulty++;
            if (currentDifficulty > 15 && spawnTickLength> 2 )
                spawnTickLength -= 0.1f; 
            Debug.Log(currentDifficulty + " " + spawnTickLength);
        }
    }
}
