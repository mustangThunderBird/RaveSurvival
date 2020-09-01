using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public GameObject ammoPrefab;
    public GameObject bruhEnemyPrefab;
    public GameObject cringeEnemyPrefab;
    public GameObject joeEnemyPrefab;

    //TODO we will need to communicate with the player controller script to set playerIsAlive to false when player dies
    private bool playerIsAlive = true;

    public float spawnRangeX = 40f;
    public float spawnRangeZ = 40f;

    public int levelNumber = 1;

    void Start()
    {
        StartCoroutine(SpawnFoes());
        StartCoroutine(SpawnAmmo());
    }

    //Spawn Foes is used to manage how many foes are spawned and at what intervals
    IEnumerator SpawnFoes()
    {
        levelNumber = 1;
        int numFoesKilled = 0;
        GetEnemyKillCount.totalKills = GetEnemyKillCount.killCount;
        while (playerIsAlive) //loop should end when the player dies
        {
            GetEnemyKillCount.waveNumber = levelNumber;
            int numFoesPerWave = GetNumFoesPerWave(levelNumber);
            int foesSpawned = 0;
            numFoesKilled = 0;
            GetEnemyKillCount.killCount = 0;
            while (numFoesKilled != numFoesPerWave)
            {
                if (foesSpawned < numFoesPerWave)
                {
                    yield return new WaitForSeconds(7f);
                    for (int i = 0; i < numFoesPerWave; i++) //loop should end when all foes have spawned for that round
                    {
                        int spawnPositionEnemy = (int)Mathf.Round(Random.Range(0f, 16f));
                        Instantiate(enemyPrefab, transform.GetChild(spawnPositionEnemy).position, enemyPrefab.transform.rotation);
                        foesSpawned++;
                        yield return new WaitForSeconds(Random.Range(.2f, 1.3f));
                        numFoesKilled = GetEnemyKillCount.killCount;
                        if(levelNumber % 3 == 0 && i % 10 == 0)
                        {
                            Instantiate(bruhEnemyPrefab, transform.GetChild((int)Mathf.Round(Random.Range(0f, 16f))).position, bruhEnemyPrefab.transform.rotation);
                            foesSpawned++;
                            i++;
                        }
                        if(levelNumber % 5 == 0 && i % 22 == 0)
                        {
                            Instantiate(cringeEnemyPrefab, transform.GetChild((int)Mathf.Round(Random.Range(0f, 16f))).position, cringeEnemyPrefab.transform.rotation);
                            foesSpawned++;
                            i++;
                        }
                        if(levelNumber % 16 == 0 && i % 120 == 0)
                        {
                            Instantiate(joeEnemyPrefab, transform.GetChild((int)Mathf.Round(Random.Range(0f, 16f))).position, joeEnemyPrefab.transform.rotation);
                            foesSpawned++;
                            i++;
                        }
                        if(levelNumber >= 17)
                        {
                            GetEnemyKillCount.isJoeKilled = true;
                        }
                    }
                }
                numFoesKilled = GetEnemyKillCount.killCount;
                if (numFoesKilled < numFoesPerWave)
                {
                    yield return null;
                }

            }
            levelNumber++;
            GetEnemyKillCount.waveNumber = levelNumber;
        }
    }
    IEnumerator SpawnAmmo()
    {
        while(playerIsAlive)
        {
            yield return new WaitForSeconds(420f);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), .01f, Random.Range(-spawnRangeZ, (spawnRangeZ - 10)));
            Instantiate(ammoPrefab, spawnPos, ammoPrefab.transform.rotation);
            
        }
        yield return null;
    }

    //takes in the level number as a parameter and returns the number of foes for that wave
    int GetNumFoesPerWave(int levelNumber)
    {
        int numFoes = 1;
        if (levelNumber == 1)
        {
            numFoes = 10;
            return numFoes;
        }
        numFoes = (10 * levelNumber) + (10 / levelNumber) + levelNumber;
        return numFoes;
    }
}
