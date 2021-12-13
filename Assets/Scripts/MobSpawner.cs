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
    [SerializeField] AudioSource mobSound;

    void Start()
    {
        StartCoroutine(StartSpawner());
    }

    void Update()
    {
        if (MobContainer.transform.childCount < 0)
            mobSound.Pause();
        else if (!mobSound.isPlaying)
            mobSound.Play();
    }

    IEnumerator StartSpawner()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(mobSpawnerSetting.SpawnRate);
            if (MobContainer.transform.childCount < mobSpawnerSetting.MaxNumberOfMobs)
            {
                Instantiate(mobsToSpawn[Random.Range(0, mobsToSpawn.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].gameObject.transform.position, Quaternion.identity, MobContainer.transform);
            }
        }
    }
}
