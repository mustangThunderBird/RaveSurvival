using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRagdolls : MonoBehaviour
{
    public GameObject[] ragdollArray;
    public int index;
    public int xRange = 8;

    void Start()
    {
        StartCoroutine(RandomRagdolls());
    }

    
    void Update()
    {
        RandomRagdolls();
    }

    IEnumerator RandomRagdolls()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), 8, 12);
            Quaternion randomAngle = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
            int index = Random.Range(0, ragdollArray.Length);
            GameObject ragdoll = Instantiate(ragdollArray[index], spawnPosition, randomAngle);
            yield return new WaitForSeconds(Random.Range(1f, 2.3f));
            Destroy(ragdoll);
        }
    }
}
