using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    private GameObject target;
    private GameObject crosshair;
    private GameObject fairy;
    private GameObject projectileToUse;
    private float damagePerShot = 10f;

    //private GameObject projectileSocket;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("CrosshiarCanvas");
        crosshair.SetActive(false);
        fairy = GameObject.Find("Fairy");
        projectileToUse = GameObject.Find("FireBall");
        damagePerShot = 10f;
        //projectileSocket = GameObject.Find("FairyPosition");
    }

    void SpawnProjectile()
    {
       
        GameObject newProjectile = Instantiate(projectileToUse, fairy.transform.position, Quaternion.identity);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        //projectileComponent.SetDamage(damagePerShot);

        //transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

        Vector3 unitVectorToPlayer = (target.transform.position - fairy.transform.position).normalized;
        float projectileSpeed = projectileComponent.projectileSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 9;
        //layerMask = ~layerMask;
        RaycastHit hit;

        Debug.Log($"layerMask: {layerMask}");

        if (Input.GetAxis("XBoxFire2") > 0.1f || Input.GetButton("Fire2"))
        {
            crosshair.SetActive(true);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, LayerMask.GetMask("Enemy")))
            {
                Debug.Log(hit.collider.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            if (Input.GetButton("Fire1"))
            {
                //SpawnProjectile();
                Debug.Log("Fire");
            }
        }
        else// if(Input.GetAxis("XBoxFire2") <= 0.1f || Input.GetButtonUp("Fire2"))
        {
            crosshair.SetActive(false);
        }
    }
}
