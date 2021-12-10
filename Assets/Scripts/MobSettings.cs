using UnityEngine;

[CreateAssetMenu(fileName = "New Mob Setting", menuName = "ScriptableObjects/Settings/Mob Setting")]
public class MobSettings : ScriptableObject
{
    [Range(1, 10)]
    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int health;
    public int Health { get { return health; } }
}
