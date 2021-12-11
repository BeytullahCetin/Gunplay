using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] ParticleSystem muzzleFlash;
    GameObject _currentWeapon;
    float nextTimeToFire = 0f;

    void Start()
    {
        _currentWeapon = Instantiate(weapon.WeaponObject);
        _currentWeapon.transform.parent = transform;
        _currentWeapon.transform.localPosition = Vector3.zero;
        _currentWeapon.transform.localRotation = Quaternion.identity;

        muzzleFlash = _currentWeapon.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (InputManager.Instance.ShootButton && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / weapon.RateOfFire;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(_currentWeapon.transform.position, -_currentWeapon.transform.up, out hit, weapon.Range))
        {
            Debug.DrawRay(_currentWeapon.transform.position, -_currentWeapon.transform.up * weapon.Range, Color.green, 4f);

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