using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{

    public float range;
    public LayerMask layer;
    public float attackSpeed;
    float m_timer;
    public float damage;

    Collider2D[] m_hitColliders = new Collider2D[20];

    Placeable m_placeable;
    bool m_isPlaced;

    // Use this for initialization
    void Start()
    {
        m_timer = attackSpeed;
        m_placeable = gameObject.GetComponent<Placeable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isPlaced)
        {
            m_isPlaced = m_placeable.IsPlaced();
        }
        else {
            m_timer -= Time.deltaTime;
            if (m_timer <= 0)
            {
                m_timer = attackSpeed;
                ShootAtEnemies();
            }
        }
    }

    void ShootAtEnemies()
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, range, m_hitColliders, layer);
        Debug.Log("Found " + hitCount + " targets!");

        if (hitCount > 0)
        {
            EnemyStats target = PickEnemy(hitCount);
            DealDamage(target);
        }
    }

    EnemyStats PickEnemy(int hitCount)
    {
        // Pick the target closest to finishing for now (greatest x)
        // TODO change to targetting based on player chosen location (default closest to tower)
        int bestX = 0;

        for (int i = 0; i < hitCount; i++)
        {
            if (m_hitColliders[i].transform.position.x > m_hitColliders[bestX].transform.position.x)
            {
                bestX = i;
            }
        }

        return m_hitColliders[bestX].GetComponent<EnemyStats>();
    }

    void DealDamage(EnemyStats target)
    {
        target.TakeDamage(damage);
    }
}
