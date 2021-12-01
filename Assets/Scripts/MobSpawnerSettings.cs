using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mob Spawner Setting", menuName = "ScriptableObjects/Settings/Mob Spawner Setting")]
public class MobSpawnerSettings : ScriptableObject
{
    [SerializeField] int spawnRate;
    public int SpawnRate{
        get{return spawnRate;}
    }
    [SerializeField] int maxNumberOfMobs;
    public int MaxNumberOfMobs{
        get{return maxNumberOfMobs;}
    }
}
