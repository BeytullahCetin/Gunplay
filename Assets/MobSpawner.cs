using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] mobsToSpawn;
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] MobSpawnerSettings mobSpawnerSetting;
    int numberOfMobs;

    void Start()
    {
        StartCoroutine(StartSpawner());
    }

    IEnumerator StartSpawner()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(mobSpawnerSetting.SpawnRate);
            if (numberOfMobs < mobSpawnerSetting.MaxNumberOfMobs)
            {
                Instantiate(mobsToSpawn[Random.Range(0, mobsToSpawn.Length)],SpawnPoints[Random.Range(0,SpawnPoints.Length)].gameObject.transform);
                numberOfMobs++;
            }
        }
    }
}
