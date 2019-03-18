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
    private bool canClick;

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
        canClick = true;

        //playerWithSword.SetActive(false);
        //audioSwordAttack = this.GetComponent<AudioSource>();

        //if (playerAnimation.clip)
        //{
        //    currentAttack = playerAnimation.clip;
        //}
        //else
        //{
        //    currentAttack = playerAnimation["Idle"].clip;
        //}
    }
    //void Awake()
    //{
    //    playerAnimation = GetComponent<Animation>() as Animation;
    //}

    //public void GetSword()
    //{
    //    hasSword = true;
    //    //playerWithSword.SetActive(true);
    //    //Destroy(gameObject);
    //    //playerWithSword.transform.position = transform.position;
    //}

    //private enum ActionState
    //{
    //    Attack1,
    //    Attack2,
    //    Attack3,
    //    Attack4,
    //    Idle
    //}
    //private ActionState actionState = ActionState.Idle;

    //void AttackLogic()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        if(actionState != ActionState.Attack1 && actionState != ActionState.Attack2)
    //        {
    //            actionState = ActionState.Attack1;
    //        }else if(actionState == ActionState.Attack1 && playerAnimation[currentAttack.name].time > 1.0f)
    //        {
    //            actionState = ActionState.Attack2;
    //        }
    //    }
    //}
    //void Attacks()
    //{
    //    float delayTime = 0f;
    //    switch (actionState)
    //    {
    //        case ActionState.Attack1:
    //            delayTime = -0.1f;
    //            playerAnimation.CrossFade("Attack1", 0.15f);
    //            currentAttack = playerAnimation["Attack1"].clip;
    //            break;
    //        case ActionState.Attack2:
    //            delayTime = -0.1f;
    //            playerAnimation.CrossFade("Attack2", 0.15f);
    //            currentAttack = playerAnimation["Attack2"].clip;
    //            break;
    //        case ActionState.Attack3:
    //            delayTime = -0.1f;
    //            playerAnimation.CrossFade("Attack3", 0.15f);
    //            currentAttack = playerAnimation["Attack3"].clip;
    //            break;
    //        case ActionState.Attack4:
    //            delayTime = -0.1f;
    //            playerAnimation.CrossFade("Attack4", 0.15f);
    //            currentAttack = playerAnimation["Attack4"].clip;
    //            break;
    //        case ActionState.Idle:
    //            break;
    //        default:
    //            break;
    //    }
    //    //Switch to defalt if an animation is almost over
    //    if(playerAnimation[currentAttack.name].time > (playerAnimation[currentAttack.name].length + delayTime))
    //    {
    //        actionState = ActionState.Idle;
    //        currentAttack = playerAnimation["Idle"].clip;
    //    }
    //}
    private void ComboStarter()
    {
        if (canClick)
        {
            numOfClicks = 1;
        }
        if (numOfClicks == 1)
        {
            m_Animator.SetInteger("Animation", 1);
        }
    }

    public void ComboCheck()
    {
        canClick = false;
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && numOfClicks == 1)
        {
            m_Animator.SetInteger("Animation", 5);
            canClick = true;
            numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && numOfClicks >= 2)
        {
            m_Animator.SetInteger("Animation", 2);
            canClick = true;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && numOfClicks == 2)
        {
            m_Animator.SetInteger("Animation", 5);
            canClick = true;
            numOfClicks = 0;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && numOfClicks >= 3)
        {
            m_Animator.SetInteger("Animation", 3);
            canClick = true;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
        {
            Debug.Log("Attack 3");
            m_Animator.SetInteger("Animation", 5);
            canClick = true;
            numOfClicks = 0;
        }

        canClick = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ComboStarter();
        }

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
