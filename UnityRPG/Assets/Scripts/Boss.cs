﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Boss : MonoBehaviour
{
    [SerializeField] private float maxHealthPoints = 1000f;
    [SerializeField] private float chaseRadius = 8.7f;
    [SerializeField] private float punchRadius = 2f;
    [SerializeField] private float swipRadius = 4f;
    [SerializeField] private float jumpAttackRadius = 11f;
    private GameObject BossCol;
    //[SerializeField] GameObject projectileToUse;
    //[SerializeField] GameObject projectileSocket;
    //[SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);


    private bool isAttacking = false;
    [SerializeField] float damagePerShot = 50f;
    [SerializeField] float intervalBetweenShots = 0.5f;


    float currentHealthPoints = 1000f;
    AIEnemyControl aIEnemyControl = null;
    ThirdPersonEnemy thirdPersonEnemy = null;
    //ThirdPersonEnemy thirdPersonEnemy = null;
    GameObject player = null;

    Animator m_Animator;    //should be in the ThirdPersonEney.cs
    float rotateSpeed = 3f;

    [SerializeField] private AudioSource attackSFX;
    //AudioClip attackSFX;


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
        attackSFX = GetComponent<AudioSource>();
        BossCol = GameObject.FindGameObjectWithTag("EnemyWeapon");
        currentHealthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        BossAttack fistComponent = BossCol.GetComponent<BossAttack>();
        fistComponent.SetDamage(damagePerShot);

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotateSpeed * Time.deltaTime);

        if (distanceToPlayer <= punchRadius)// && !isAttacking)
        {
            m_Animator.SetBool("IsSwip", false);
            m_Animator.SetBool("IsPunch", true);
            //isAttacking = true;
            
            //InvokeRepeating("SpawnProjectile", 0f, intervalBetweenShots);
            //SpawnProjectile();
        }

        if(distanceToPlayer > punchRadius && distanceToPlayer <= swipRadius)// && !isAttacking)
        {
            m_Animator.SetBool("IsPunch", false);
            m_Animator.SetBool("IsSwip", true);
            //isAttacking = true;
            
        }

        if(distanceToPlayer > swipRadius)
        {
            m_Animator.SetBool("IsSwip", false);
            //isAttacking = false;
            //CancelInvoke();
        }

        // Chasing player
        if (distanceToPlayer <= chaseRadius && distanceToPlayer > swipRadius && isAttacking == false)
        {
            aIEnemyControl.SetTarget(player.transform);
        }
        else
        {
            aIEnemyControl.SetTarget(transform);
        }

        // Jump Attack
        //if(distanceToPlayer > chaseRadius && distanceToPlayer <= jumpAttackRadius)
        //{
        //    m_Animator.SetTrigger("JumpAttack");
        //    transform.position = player.transform.position * Time.deltaTime; 
        //}

        //if enemy hp <= 0: death animation, stop chasing player, Clean it from scene after 3 sec.
        if(currentHealthPoints <= 0f)
        {
            m_Animator.SetTrigger("Die");
            aIEnemyControl.SetTarget(transform);
            Destroy(gameObject, 3f);
        }
    }

    private void CannotMove()
    {
        isAttacking = true;
    }
    private void CanMove()
    {
        isAttacking = false;
    }

    private void AttackStart()
    {
        BossCol.SetActive(true);
    }
    private void AttackEnd()
    {
        BossCol.SetActive(false);
    }

    //void SpawnProjectile()
    //{
    //    GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
    //    Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
    //    projectileComponent.SetDamage(damagePerShot);

    //    //transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

    //    Vector3 unitVectorToPlayer = (player.transform.position + aimOffset - projectileSocket.transform.position).normalized;
    //    float projectileSpeed = projectileComponent.projectileSpeed;
    //    newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            attackSFX.Play();
            currentHealthPoints -= 20f;
            
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, punchRadius);

        Gizmos.color = new Color(0f, 255f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, swipRadius);

        Gizmos.color = new Color(0f, 0f, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);

        Gizmos.color = new Color(255f, 0f, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, jumpAttackRadius);
    }
}