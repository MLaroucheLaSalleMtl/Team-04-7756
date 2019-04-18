using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Zombie : MonoBehaviour
{
    public float maxHealthPoints = 150f;
    public float currentHealthPoints = 150f;
    public float chaseRadius = 5f;
    public float attackRadius = 2f;
    [SerializeField] GameObject ZombieArm;

    [SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);

    private GameObject FistCol;

    private bool isAttacking = false;
    private bool isDoingAttack = false;
    [SerializeField] float damage = 20;
    [SerializeField] float intervalBetweenShots = 0.5f;


    AIZombieControl aIEnemyControl = null;
    ThirdPersonEnemy thirdPersonEnemy = null;
    //ThirdPersonEnemy thirdPersonEnemy = null;
    GameObject player = null;

    Animator m_Animator;
    float rotateSpeed = 3f;

    private AudioSource attackSFX;




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
        aIEnemyControl = GetComponent<AIZombieControl>();
        thirdPersonEnemy = GetComponent<ThirdPersonEnemy>();
        m_Animator = GetComponent<Animator>();
        attackSFX = this.GetComponent<AudioSource>();
        FistCol = ZombieArm;

    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        BossAttack fistDamage = ZombieArm.GetComponent<BossAttack>();
        fistDamage.SetDamage(damage);
        if (currentHealthPoints > 0)
        {


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotateSpeed * Time.deltaTime);

            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle"))
            {
                m_Animator.SetBool("IsAttacking", false);
              
                if (distanceToPlayer <= attackRadius)
                {
                    m_Animator.SetInteger("Animation", 1);
                }

                else if (distanceToPlayer > attackRadius)
                {
                    m_Animator.SetInteger("Animation", 0);
                }

            }
            else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !m_Animator.IsInTransition(0))
            {
                m_Animator.SetBool("IsAttacking", true);
                if (distanceToPlayer <= attackRadius)
                {
                    m_Animator.SetInteger("Animation", 1);
                }

                else if (distanceToPlayer > attackRadius)
                {
                    m_Animator.SetInteger("Animation", 0);
                }
            }


        }
        else if (currentHealthPoints <= 0)
        {
            m_Animator.SetTrigger("Die");
            CancelInvoke();
            aIEnemyControl.SetTarget(transform);
            // this.projectileToUse.SetActive(false);
            Destroy(gameObject, 3f);
        }





        if (distanceToPlayer <= chaseRadius && distanceToPlayer >= attackRadius)
        {
            aIEnemyControl.SetTarget(player.transform);
        }
        else
        {
            aIEnemyControl.SetTarget(transform);
        }


    }

    /*
    private void SpawnProjectile()
    {
        
        GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.SetDamage(damagePerShot);

        //transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

        Vector3 unitVectorToPlayer = (player.transform.position + aimOffset - projectileSocket.transform.position).normalized;
        float projectileSpeed = projectileComponent.projectileSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            attackSFX.Play();
            currentHealthPoints -= 25f;

        }
    }

    //private void OnTriggerEnter()
    private void AttackStart()
    {
        if (m_Animator.GetBool("IsAttacking") == true)
        {
            ZombieArm.SetActive(true);
        }
        else if (m_Animator.GetBool("IsAttacking") == false)
        {
            ZombieArm.SetActive(false);
        }

    }
    private void AttackEnd()
    {
        ZombieArm.SetActive(false);

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