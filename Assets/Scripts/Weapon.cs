using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject weaponObject;
    public GameObject WeaponObject{ get { return weaponObject; } }

    [SerializeField] int rateOfFire;
    public int RateOfFire { get { return rateOfFire; } }

    [SerializeField] int damage;
    public int Damage { get { return damage; } }
    
    [SerializeField] int range;
    public int Range { get { return range; } }
}