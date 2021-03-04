using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int enemyHealth = 5;
    [SerializeField] int damagePerShot = 1;    

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other) 
    {
        enemyHealth = enemyHealth - damagePerShot;              
    }
}
