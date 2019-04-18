using System.Collections;
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
    private GameObject FistCol;
    private GameObject ArmCol;
    //[SerializeField] GameObject projectileToUse;
    //[SerializeField] GameObject projectileSocket;
    //[SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);
    [SerializeField] GameObject fistComponent;
    [SerializeField] GameObject armComponent;

    private bool isAttacking = false;
    [SerializeField] float damagePerShot = 50f;
    [SerializeField] float intervalBetweenShots = 0.5f;


    public float currentHealthPoints = 1000f;
    AIEnemyControl aIEnemyControl = null;
    ThirdPersonEnemy thirdPersonEnemy = null;
    //ThirdPersonEnemy thirdPersonEnemy = null;
    GameObject player = null;
   // [SerializeField] GameObject TheBoss;

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
        FistCol = fistComponent;
        ArmCol = armComponent;//GameObject.FindGameObjectWithTag("Fist");
        currentHealthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        BossAttack fistDamage = fistComponent.GetComponent<BossAttack>();
        fistDamage.SetDamage(damagePerShot / 4);
        BossAttack ArmDamage = armComponent.GetComponent<BossAttack>();
        ArmDamage.SetDamage(damagePerShot);

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotateSpeed * Time.deltaTime);

            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle"))
            {
                if(distanceToPlayer <= punchRadius)
                {
                    m_Animator.SetInteger("Animation", 2);
                }else if(distanceToPlayer > punchRadius && distanceToPlayer <= swipRadius)
                {
                    m_Animator.SetInteger("Animation", 1);
                }else if(distanceToPlayer > swipRadius)
                {
                    m_Animator.SetInteger("Animation", 0);
                }

            }
            else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Swip") && !m_Animator.IsInTransition(0))
            {
                m_Animator.SetBool("IsSwip", true);
                m_Animator.SetBool("IsPunch", false);

                if(distanceToPlayer <= punchRadius)
                {
                    m_Animator.SetInteger("Animation", 2);
                }else if(distanceToPlayer > swipRadius)
                {
                    m_Animator.SetInteger("Animation", 0);
                }else if (distanceToPlayer > punchRadius && distanceToPlayer <= swipRadius)
                {
                    m_Animator.SetInteger("Animation", 1);
                }
            }
            else if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && !m_Animator.IsInTransition(0))
            {
                m_Animator.SetBool("IsSwip", false);
                m_Animator.SetBool("IsPunch", true);

                if (distanceToPlayer <= punchRadius)
                {
                    m_Animator.SetInteger("Animation", 2);
                }
                else if (distanceToPlayer > swipRadius)
                {
                    m_Animator.SetInteger("Animation", 0);
                }else if(distanceToPlayer > punchRadius && distanceToPlayer <= swipRadius)
                {
                    m_Animator.SetInteger("Animation", 1);
                }
            }

            /*
                if (distanceToPlayer > punchRadius && !m_Animator.IsInTransition(0) && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle"))
            {
                m_Animator.SetBool("IsSwip", true);
                m_Animator.SetBool("IsPunch", false);
            }
            else if(distanceToPlayer < punchRadius && !m_Animator.IsInTransition(0) && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle"))
            {
                m_Animator.SetBool("IsSwip", false);
                m_Animator.SetBool("IsPunch", true);
            }*/
        /*
        else if(distanceToPlayer > punchRadius && distanceToPlayer <= swipRadius)// && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && !isAttacking)//!m_Animator.IsInTransition(0) &&
        {

            m_Animator.SetBool("IsSwip", true);
            m_Animator.SetBool("IsPunch", false);

            if (distanceToPlayer <= punchRadius && !m_Animator.IsInTransition(0) && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Swip")) //&& m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Swip"))
            {
                m_Animator.SetBool("IsSwip", false);
                m_Animator.SetBool("IsPunch", true);
            }
            else if(distanceToPlayer >= punchRadius && !m_Animator.IsInTransition(0) && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Swip"))
            {
                m_Animator.SetBool("IsSwip", true);
                m_Animator.SetBool("IsPunch", false);
            }
            
            //isAttacking = true;
            
        }*/
        /*
        if(distanceToPlayer > swipRadius && !m_Animator.IsInTransition(0))
        {
            m_Animator.SetBool("IsSwip", false);
            m_Animator.SetBool("IsPunch", false);
            //isAttacking = false;
            //CancelInvoke();
        }
        */
        // Chasing player
        //if (distanceToPlayer <= chaseRadius && distanceToPlayer > swipRadius && isAttacking == false)
       // {
            //aIEnemyControl.SetTarget(player.transform);
      //  }
       // else
      //  {
          // aIEnemyControl.SetTarget(transform);
       // }

        // Jump Attack
        //if(distanceToPlayer > chaseRadius && distanceToPlayer <= jumpAttackRadius)
        //{
        //    m_Animator.SetTrigger("JumpAttack");
        //    transform.position = player.transform.position * Time.deltaTime; 
        //}

        //if enemy hp <= 0: death animation, stop chasing player, Clean it from scene after 3 sec.
        if(currentHealthPoints <= 0f)
        {
           
            isAttacking = false;
            m_Animator.SetTrigger("Die");
            CancelInvoke();
        
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

    ///*
    private void AttackStart()
    {

        if (m_Animator.GetBool("IsSwip") == true && !m_Animator.IsInTransition(0))
        {
            Debug.Log("Is Swip is found true");
           // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !m_Animator.IsInTransition(0))
           // {
                Debug.Log("We have entered the if statement for SWIP");
                // && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle")
                armComponent.SetActive(true);
                fistComponent.SetActive(false);
           // }
            //}

        }
        else if ((m_Animator.GetBool("IsPunch") == true))
        {
            Debug.Log("Is Punch is found true");
            // while (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Swip"))
            //{
            //if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !m_Animator.IsInTransition(0))
            //{
                Debug.Log("We have entered the if statement for PUNCH");
                //  && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Idle")
                fistComponent.SetActive(true);
                armComponent.SetActive(false);
          //  //} // }

        }
        else
        {
            fistComponent.SetActive(false);
            armComponent.SetActive(false);
        }
    }
    //
    
    private void AttackEnd()
    {
        Debug.Log("Attack has ended");
       armComponent.SetActive(false);
        fistComponent.SetActive(false);
    }//

    
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
