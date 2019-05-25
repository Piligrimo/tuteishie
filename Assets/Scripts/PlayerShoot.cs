using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    class Bullet 
    {
        GameObject gameObject;
        Rigidbody2D rigidbody;
        float speed=7;
        public Bullet (GameObject go)
        {
            gameObject = go;
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            go.SetActive(false);
        }
        public void Shoot(Vector2 target,Vector3 startpoint)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = startpoint;
            Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            rigidbody.velocity = (target - position).normalized*speed;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) * 180 / Mathf.PI);
        }
        public bool CheckIfActive()
        {
            return gameObject.activeSelf;
        }
        public void CheckIfFar()
        {
            Vector3 pos = gameObject.transform.position;
            if (pos.x > 15 || pos.y > 8 || pos.y < -8)
                gameObject.SetActive(false);
        }
    }
    int size=50;
    public GameObject bulletPref,eyes;
    Stack<Bullet> bulletPool;
    List<Bullet> activeBullets;
    float cooldown=0.2f, lastShot;
    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
        bulletPool = new Stack<Bullet>();
        activeBullets = new List<Bullet>();
        for (int i = 0; i < size; i++)
        {
            bulletPool.Push(new Bullet(Instantiate(bulletPref)));
        }
        
    }

    private void OnEnable()
    {
        StartCoroutine(checkBullets());
    }
    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetMouseButtonDown(0) && */Time.time-lastShot>cooldown && Camera.main.ScreenToWorldPoint(Input.mousePosition).x>transform.position.x)
        {
            Bullet b = bulletPool.Pop();           
            b.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition),eyes.transform.position);
            activeBullets.Add(b);
            lastShot = Time.time;
            eyes.SetActive(true);
        }
        if (eyes.activeSelf && Time.time - lastShot > 0.6f * cooldown)
        {
            eyes.SetActive(false);
        }

    }

    IEnumerator checkBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Bullet[] array = new Bullet[activeBullets.Count];
            activeBullets.CopyTo(array);
            foreach (Bullet bullet in array)
            {
                bullet.CheckIfFar();
                if (!bullet.CheckIfActive())
                {
                    bulletPool.Push(bullet);
                    activeBullets.Remove(bullet);
                }
            }
        }
    }
}
