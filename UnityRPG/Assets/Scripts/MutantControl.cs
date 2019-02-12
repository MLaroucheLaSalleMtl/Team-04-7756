using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantControl : MonoBehaviour
{
    [SerializeField] private Transform target;

    Animator m_Animator;
    private float interval;
    private NavMeshAgent agent;

    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        interval = Time.deltaTime;
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        //target = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        interval += Time.deltaTime;
        if (interval > 5)
        {
            m_Animator.SetTrigger("Swiping");
            interval = 0f;
        }
        //m_Animator.SetFloat("Distance", Vector3.Distance(target.position, this.transform.position));
        Debug.Log(Vector3.Distance(target.position, this.transform.position));
        //if (Vector3.Distance(destination, target.position) > 100)
        //{
        //    m_Animator.SetTrigger("JumpAttack");
        //}
        //else
        //{
        //    m_Animator.SetTrigger("Swiping");
        //    interval = 0f;
        //}
        //if(Vector3.Distance())
    }
}
