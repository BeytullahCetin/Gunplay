using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    ParticleSystem muzzleFlash;
    GameObject _currentWeapon;
    AudioSource weaponAudio;
    float nextTimeToFire = 0f;
    Player player;

    void Start()
    {
        _currentWeapon = Instantiate(weapon.WeaponObject);
        _currentWeapon.transform.parent = transform;
        _currentWeapon.transform.localPosition = Vector3.zero;
        _currentWeapon.transform.localRotation = Quaternion.identity;

        weaponAudio = _currentWeapon.GetComponent<AudioSource>();

        muzzleFlash = _currentWeapon.GetComponentInChildren<ParticleSystem>();

        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (InputManager.Instance.ShootButton && Time.time >= nextTimeToFire && !player.IsDead)
        {
            nextTimeToFire = Time.time + 1f / weapon.RateOfFire;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        weaponAudio.Play();

        RaycastHit hit;
        if (Physics.Raycast(_currentWeapon.transform.position, -_currentWeapon.transform.up, out hit))
        {
            Transform switchHit = hit.transform;
            switch (switchHit.tag)
            {
                case "Zombie":
                    switchHit.GetComponent<Mob>().TakeDamage(hit.point, Quaternion.LookRotation(hit.normal), weapon.Damage);
                    break;

                default:
                    Debug.Log(switchHit.name + " Shot!");
                    break;
            }

        }

    }
}
