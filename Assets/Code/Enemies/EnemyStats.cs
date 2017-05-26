using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float Health;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + " took " + damage + " damage!");
        Health -= damage;
        if (Health <= 0)
            Die();
    }

    void Die()
    {
        // TODO: grant resource on death.
        Destroy(gameObject);
    }
}
