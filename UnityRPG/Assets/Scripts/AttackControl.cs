using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_Animator.SetTrigger("Attack");
        }
    }
}
