using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] mobsToSpawn;
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject MobContainer;
    [SerializeField] Transform target;
    [SerializeField] MobSpawnerSettings mobSpawnerSetting;

    void Start()
    {
        StartCoroutine(StartSpawner());
    }

    IEnumerator StartSpawner()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(mobSpawnerSetting.SpawnRate);
            if (MobContainer.transform.childCount < mobSpawnerSetting.MaxNumberOfMobs)
            {
                Instantiate(mobsToSpawn[Random.Range(0, mobsToSpawn.Length)], SpawnPoints[Random.Range(0,SpawnPoints.Length)].gameObject.transform.position, Quaternion.identity,  MobContainer.transform);
            }
        }
    }
}
