using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;
    ParticleSystem.EmissionModule particle;
    private float particleTimer;
    private bool isEnemy;
    [SerializeField] AudioSource audioSwordAttack;

    // Start is called before the first frame update
    void Start()
    {
        particleTimer = Time.deltaTime;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        particle = this.GetComponentInChildren<ParticleSystem>().emission;
        particle.enabled = false;
        isEnemy = false;
        audioSwordAttack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        particleTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            m_Animator.SetTrigger("Attack");
            particle.enabled = true;
            particleTimer = 0.0f;
        }
        if(particleTimer > 1.0f)
        {
            particle.enabled = false;
            isEnemy = false;
        }
    }

    public void SwingSword()
    {
        isEnemy = true;
    }

    public void SwordAttack()
    {
        if(isEnemy == true)
        {
            Debug.Log("Sword Attack");
            audioSwordAttack.Play();
        }
    }
}
