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
        swordCol = GameObject.Find("SwordCol");
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

    private void OpenCol()
    {
        swordCol.SetActive(true);
    }
    private void CloseCol()
    {
        swordCol.SetActive(false);
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
    }
    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            ComboStarter();
        }
    }
}
