using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public float amount= 100;
    public Image oxyBar;
    bool poisoned = false;
    public GameObject player;
    private void Update()
    {
        oxyBar.fillAmount = amount / 100;
        if (poisoned)
            amount -= Time.deltaTime*5;
    }

    public void Poison()
    {
        StartCoroutine(PoisonRoutine());
    }
    public IEnumerator PoisonRoutine()
    {
        poisoned = true;
        foreach (SpriteRenderer sr in player.GetComponentsInChildren<SpriteRenderer>())
            sr.color = new Color(0.5f, 1, 0.5f);
        yield return new WaitForSeconds(5);
        poisoned = false;
        foreach (SpriteRenderer sr in player.GetComponentsInChildren<SpriteRenderer>())
            sr.color = new Color(1, 1, 1);
    }
}
