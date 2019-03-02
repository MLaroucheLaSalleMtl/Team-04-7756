
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100f;
    [SerializeField] float chaseRadius = 5f;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] GameObject projectileToUse;
    [SerializeField] GameObject projectileSocket;


    bool isAttacking = false;
    [SerializeField] float damagePerShot = 9f;


    float currentHealthPoints = 100f;
    AIEnemyControl aIEnemyControl = null;
    //ThirdPersonEnemy thirdPersonEnemy = null;
    GameObject player = null;

    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aIEnemyControl = GetComponent<AIEnemyControl>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= attackRadius && !isAttacking)
        {
            isAttacking = true;
            SpawnProjectile();
        }

        if (distanceToPlayer <= chaseRadius)
        {
            aIEnemyControl.SetTarget(player.transform);
        }
        else
        {
            aIEnemyControl.SetTarget(transform);
        }
    }

    void SpawnProjectile()
    {
        GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.identity);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.damageCaused = damagePerShot;
        Vector3 unitVectorToPlayer = (player.transform.position - projectileSocket.transform.position).normalized;
        float projectileSpeed = projectileComponent.projectileSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = new Color(0f, 0f, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}

