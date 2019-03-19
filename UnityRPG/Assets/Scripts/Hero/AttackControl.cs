using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AttackControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    Animation playerAnimation;
    CapsuleCollider m_Capsule;
    ParticleSystem.EmissionModule particle;

    [SerializeField] private GameObject swordCol;
    //private GameObject swordCol;
    [SerializeField] private GameObject projectile;
    [SerializeField] GameObject projectileSocket;
    [SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);

    private float particleTimer;
    AnimationClip currentAttack;
    //private float attackTimer;
    public bool hasSword;
    private bool isEnemy;
    private ThirdPersonCharacter Maria;
    private bool canAttack = true;

    private int numOfClicks;
    private int countClicks;
    private bool canClick;

    private float timer;
    private bool isButtonDown;

    // Start is called before the first frame update
    void Start()
    {
        Maria = GetComponent<ThirdPersonCharacter>();
        particleTimer = Time.deltaTime;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        particle = this.GetComponentInChildren<ParticleSystem>().emission;
        particle.enabled = false;
        isEnemy = false;
        //swordCol = GameObject.Find("SwordCol").GetComponent<GameObject>();
        swordCol.SetActive(false);
        hasSword = false;

        numOfClicks = 0;
        countClicks = 0;
        canClick = true;

        timer = Time.deltaTime;
    }
    
    private void ComboStarter()
    {
        //Debug.Log($"Clicks : {numOfClicks}");

        if (canClick)// && timer < 0.5f)
        {
            numOfClicks++;
        }
        if (numOfClicks >= 1)
        {
            m_Animator.SetBool("Attacking", true);
            m_Animator.SetTrigger("Attack1");
        }
    }

    private void SetZero()
    {
        numOfClicks = 0;
        m_Animator.SetInteger("Animation", 0);
        canClick = true;
        m_Animator.SetBool("Attacking", false);
    }

    public void ComboCheck()
    {
        canClick = false;
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && numOfClicks == 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 0);
            canClick = false;
            //numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && numOfClicks > 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 2);
            canClick = true;
            //numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && numOfClicks == 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 0);
            canClick = true;
            numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && numOfClicks > 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 3);
            canClick = true;
            //numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3") && numOfClicks == 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 0);
            canClick = true;
            //numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3") && numOfClicks >= 1)
        {
            m_Animator.SetBool("Attacking", false);
            m_Animator.SetInteger("Animation", 4);
            canClick = true;
            //numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_4"))
        {
            //m_Animator.SetBool("Attacking", false);
            Debug.Log("Attack 4");
            m_Animator.SetInteger("Animation", 0);
            canClick = true;
            numOfClicks = 0;
        }

        //else
        //{
        //    m_Animator.SetBool("Attacking", false);
        //    m_Animator.SetInteger("Animation", 0);
        //    canClick = true;
        //    numOfClicks = 0;
        //}

        //numOfClicks = 0;
        //if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3") && numOfClicks > 1)
        //{
        //    m_Animator.SetInteger("Animation", 5);
        //    canClick = true;
        //    numOfClicks = 0;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            ComboStarter();
        }
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    isButtonDown = false;
        //    m_Animator.SetBool("IsButtonDown", false);
        //}
        //if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && isButtonDown)
        //{

        //}
        //if(currentAttack != null)
        //{
        //    AttackLogic();
        //    Attacks();
        //}

            //particleTimer += Time.deltaTime;
            //float attackTimer = Time.deltaTime;
            //if (Input.GetButtonDown("Fire1") && canAttack)// && Maria.Stamina >= 15)// && hasSword == true)
            //{
            //    if(actionState != ActionState.Attack1 && actionState != ActionState.Attack2)
            //    {
            //        actionState = ActionState.Attack1;
            //    }else if(actionState == ActionState.Attack1 && playerAnimation[currentAttack.name].time > 1.0f)
            //    {
            //        actionState = ActionState.Attack2;
            //    }
            //    m_Animator.SetBool("Attacking", true);
            //    m_Animator.SetTrigger("Attack1");

            //    particle.enabled = true;
            //    particleTimer = 0.0f;
            //    //Maria.Stamina -= 15;
            //    canAttack = false;
            //    Invoke("ResetAttack", 1.0f);

            //}
            //if (Input.GetButtonDown("Fire2"))
            //{
            //    m_Animator.SetTrigger("SpellAttack");
            //}
            //if (particleTimer > 1.0f)
            //{
            //    particle.enabled = false;
            //    isEnemy = false;
            //}


            //particleTimer += Time.deltaTime;
            //if (Input.GetButtonDown("Fire1") && canAttack && Maria.Stamina >= 15)
            //{

            //    m_Animator.SetTrigger("Attack");
            //    particle.enabled = true;
            //    particleTimer = 0.0f;            
            //    Maria.Stamina -= 15;
            //    canAttack = false;
            //    Invoke("ResetAttack", 1.0f);
            //}
            //if (Input.GetButtonDown("Fire2"))
            //{
            //    m_Animator.SetTrigger("SpellAttack");
            //}
            //if(particleTimer > 1.0f)
            //{
            //    particle.enabled = false;
            //    isEnemy = false;
            //}
    }

    //public void SpellAttack()
    //{
    //    projectile = Instantiate(projectile, transform.position, transform.rotation);
    //    projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Acceleration);
    //}

    //public void SwingSword()
    //{
    //    isEnemy = true;
    //}

    //public void SwordSound()
    //{
    //    Debug.Log("Swing Sword");
    //}

    //public void SwordAttack()
    //{
    //    if (isEnemy == true)
    //    {
    //        Debug.Log("Sword Attack");
    //    }
    //}

    //public void ResetAttack()
    //{
    //    canAttack = true;
    //}

    //private void AttackStart()
    //{
    //    swordCol.SetActive(true);
    //}

    //private void AttackEnd()
    //{
    //    swordCol.SetActive(false);
    //}
}
