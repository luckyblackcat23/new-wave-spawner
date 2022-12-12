//i
//have
//no
//idea
//why
//this
//works
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    #region variables
    //public string WaveStartText;
    public Wave[] waves;
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    public static List<GameObject> points = new List<GameObject>();
    public static int enemiesAlive;
    public int currentWave;
    #endregion
    public void StartRound()
    {
        //start the spawning
        StartCoroutine(WaveSpawner());
    }

    IEnumerator WaveSpawner()
    {
        //for all enemies in the current wave...
        for (int i = 0; i < waves[currentWave].enemies.Length; i++)
        {
            //set enemies stats and spawn it
            for (int ii = 0; ii < waves[currentWave].enemies[i].EnemiesSpawned; ii++)
            {
                yield return new WaitForSeconds(waves[currentWave].enemies[i].TimeBetweenSpawns);
                enemiesAlive++;
                GameObject enemy = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
                enemy.GetComponent<Enemy>().stat = waves[currentWave].enemies[i].Enemy;
                enemy.GetComponent<Enemy>().health = waves[currentWave].enemies[i].Enemy.health;
                SpriteRenderer sprite = enemy.GetComponent<SpriteRenderer>();
                sprite.color = new Color(waves[currentWave].enemies[i].Enemy.colour.r, waves[currentWave].enemies[i].Enemy.colour.g, waves[currentWave].enemies[i].Enemy.colour.b);
            }
        }

        //when every enemy dies
        while(enemiesAlive > 0)
        {
            if(currentWave >= waves.Length)
            {
                //end game
            }
            //reset the amount of enemies that are alive and start the next wave
            enemiesAlive = 0;
            currentWave++;
            yield return null;
        }
    }
}
#region enemies and waves
//the stats for each enemy
[System.Serializable]
public class EnemyInfo
{
    public float TimeBetweenSpawns;
    public float StartDelay;
    public int EnemiesSpawned;
    public EnemyStats Enemy;
}

//each enemy in the wave
[System.Serializable]
public class Wave
{
    public EnemyInfo[] enemies;
}
#endregion