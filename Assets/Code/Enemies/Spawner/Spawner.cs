using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnDelay;
    float timer;
    public List<SpawnWave> waves;
    int currWave = -1;
    int currEnemy = 0;
    int remainingEnemies;
    // Use this for initialization
    void Start()
    {
        timer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (currWave > -1 && timer < 0 && currEnemy < waves[currWave].enemyCount.Count)
        {
            timer = spawnDelay;
            Instantiate(waves[currWave].enemy[currEnemy], transform.position, transform.rotation);
            remainingEnemies--;
            if (remainingEnemies <= 0)
            {
                currEnemy++;
                if (currEnemy < waves[currWave].enemyCount.Count)
                    remainingEnemies = waves[currWave].enemyCount[currEnemy];
            }
        }
    }

    public void StartNextWave()
    {
        currWave++;
        currEnemy = 0;
        remainingEnemies = waves[currWave].enemyCount[currEnemy];
    }
}
