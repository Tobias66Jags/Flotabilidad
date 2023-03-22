using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public BouyancyComplex bouyancyComplex;
    public Health health;

    private void Update()
    {
        if (health.maxHealth<=0)
        {
            bouyancyComplex.floatingPower = 0;
            StartCoroutine(ToLife());
        }
    }

    private IEnumerator ToLife()
    {
        yield return new WaitForSeconds(5f);
        bouyancyComplex.floatingPower = 2;
        health.maxHealth = 100;
    }
}
