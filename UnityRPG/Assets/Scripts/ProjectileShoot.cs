using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{

    [SerializeField] GameObject projectile;                       // The projectile to be launched (if the type is projectile)
    [SerializeField] Transform projectileSpawnSpot;

    [SerializeField] private AudioClip fireSound;

    [SerializeField] private ThirdPersonCharacter Maria;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Maria = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>();
        if (projectileSpawnSpot == null)
        {
            projectileSpawnSpot = gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Maria.Mana >= 15)
                {
                    Maria.Mana -= 15;
                    Fire();
                }
            }
        }

    }

    void Fire()
    {
        Debug.Log("Shot!!");
        // Reset the fireTimer to 0 (for ROF)
        //fireTimer = 0.0f;

        GameObject fireBall = Instantiate(projectile, projectileSpawnSpot.position, projectileSpawnSpot.rotation);
       // fireBall.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

        Debug.Log("Called Mana");
        // if (!infiniteAmmo)
        // {
        //   Debug.Log("Removed Mana");
        //   currentMana = currentMana - 20.0f;
        //   Debug.Log("Current Mana  " + currentMana);
        //}

        // Play the gunshot sound
        GetComponent<AudioSource>().PlayOneShot(fireSound);

    }
}
