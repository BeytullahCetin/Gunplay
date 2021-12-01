using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mob Setting", menuName = "ScriptableObjects/Settings/Mob Setting")]
public class MobSettings : ScriptableObject
{
    [Range(1,10)]
    [SerializeField] int speed;
    public int Speed{
        get{return speed;}
    }
}
