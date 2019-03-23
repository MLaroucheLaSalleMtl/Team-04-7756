﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100f;
    public float currentHealthPoints = 100f;
    [SerializeField] float chaseRadius = 5f;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] GameObject projectileToUse;
    [SerializeField] GameObject projectileSocket;
    [SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);


    private bool isAttacking = false;
    private bool isDoingAttack = false;
    [SerializeField] float damagePerShot = 9f;
    [SerializeField] float intervalBetweenShots = 0.5f;


    AIEnemyControl aIEnemyControl = null;
    ThirdPersonEnemy thirdPersonEnemy = null;
    //ThirdPersonEnemy thirdPersonEnemy = null;
    GameObject player = null;

    Animator m_Animator;    //should be in the ThirdPersonEney.cs
    float rotateSpeed = 3f;

    private AudioSource attackSFX;

    //private GameObject enemyCol;


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
        thirdPersonEnemy = GetComponent<ThirdPersonEnemy>();
        m_Animator = GetComponent<Animator>();
        attackSFX = this.GetComponent<AudioSource>();
        projectileToUse.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotateSpeed * Time.deltaTime);

        if (distanceToPlayer <= attackRadius && !isAttacking)
        {
            m_Animator.SetBool("IsAttacking", true);
            isAttacking = true;
            InvokeRepeating("SpawnProjectile", 0f, intervalBetweenShots);
            SpawnProjectile();
        }

        if(distanceToPlayer > attackRadius)
        {
            m_Animator.SetBool("IsAttacking", false);
            isAttacking = false;
            CancelInvoke();
        }

        if (distanceToPlayer <= chaseRadius && distanceToPlayer >= attackRadius && isDoingAttack == false)
        {
            aIEnemyControl.SetTarget(player.transform);
        }
        else
        {
            aIEnemyControl.SetTarget(transform);
        }

        //if enemy hp <= 0: death animation, stop chasing player, Clean it from scene after 3 sec.
        if(currentHealthPoints <= 0f)
        {
            m_Animator.SetTrigger("Die");
            //aIEnemyControl.SetTarget(transform);
            projectileToUse.SetActive(false);
            Destroy(gameObject, 3f);
        }
    }

    void SpawnProjectile()
    {
        GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.SetDamage(damagePerShot);

        //transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

        Vector3 unitVectorToPlayer = (player.transform.position + aimOffset - projectileSocket.transform.position).normalized;
        float projectileSpeed = projectileComponent.projectileSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            attackSFX.Play();
            currentHealthPoints -= 20f;
            
        }
    }

    private void CannotMove()
    {
        isDoingAttack = true;
    }
    private void CanMove()
    {
        isDoingAttack = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = new Color(0f, 0f, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
