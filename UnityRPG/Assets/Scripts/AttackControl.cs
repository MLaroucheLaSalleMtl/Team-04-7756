using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AttackControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;
    ParticleSystem.EmissionModule particle;

    [SerializeField] private GameObject swordCol;
    //private GameObject swordCol;
    [SerializeField] private GameObject projectile;
    [SerializeField] GameObject projectileSocket;
    [SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);

    private float particleTimer;
    public bool hasSword;
    private bool isEnemy;
    private ThirdPersonCharacter Maria;
    private bool canAttack = true;


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
        //playerWithSword.SetActive(false);
        //audioSwordAttack = this.GetComponent<AudioSource>();
    }
    public void GetSword()
    {
        hasSword = true;
        //playerWithSword.SetActive(true);
        //Destroy(gameObject);
        //playerWithSword.transform.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        particleTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && canAttack)// && Maria.Stamina >= 15)// && hasSword == true)
        {

            m_Animator.SetTrigger("Attack");
            particle.enabled = true;
            particleTimer = 0.0f;
            //Maria.Stamina -= 15;
            canAttack = false;
            Invoke("ResetAttack", 1.0f);

        }
        if (Input.GetButtonDown("Fire2"))
        {
            m_Animator.SetTrigger("SpellAttack");
        }
        if (particleTimer > 1.0f)
        {
            particle.enabled = false;
            isEnemy = false;
        }
        

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

    public void SpellAttack()
    {
        projectile = Instantiate(projectile, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Acceleration);
    }

    public void SwingSword()
    {
        isEnemy = true;
    }
    
    public void SwordSound()
    {
        Debug.Log("Swing Sword");
    }

    public void SwordAttack()
    {
        if(isEnemy == true)
        {
            Debug.Log("Sword Attack");
        }
    }

    public void ResetAttack()
    {
        canAttack = true;
    }

    private void AttackStart()
    {
        swordCol.SetActive(true);
    }

    private void AttackEnd()
    {
        swordCol.SetActive(false);
    }
}
