 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int difficulty;
    public float amount, maximum;
    public Enemy self;
    public enum SpawnType { inFront, behind, fixedPoint};
    public SpawnType spawnType;
    EnemyManager em;
    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.FindGameObjectWithTag("Core").GetComponent<EnemyManager>();
        

    }

    private void OnEnable()
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.color = new Color(1, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -15 || transform.position.x > 15)
        {
            em.Kill(self,0);
        }
        if (amount <= 0)
        {
            em.Kill(self,10*difficulty);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lazer")
        {
            amount -= 1;
            collision.gameObject.SetActive(false);
            StartCoroutine(DamageFX());
        }

    }
    IEnumerator DamageFX()
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.color = new Color(1, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.color = new Color(1, 1, 1);
    }
}
