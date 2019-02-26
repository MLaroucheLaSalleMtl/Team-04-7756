using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantControl : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform target;
    [SerializeField] private float walkMoveStopRadius = 3f;

    Animator m_Animator;
    private float interval;
    private NavMeshAgent agent;

    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        interval = Time.deltaTime;
        //agent = GetComponent<NavMeshAgent>();
        //destination = agent.destination;
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
        //if (Vector3.Distance(target.position, this.transform.position) > 10)
        //{
        //    m_Animator.SetTrigger("Swiping");
        //    this.transform.position = target.position;
        //}
        //m_Animator.SetFloat("Distance", Vector3.Distance(target.position, this.transform.position));

        //Debug.Log(Vector3.Distance(target.position, this.transform.position));


        //var targetPosition = transform.position - destination;
        //if(targetPosition.magnitude >= walkMoveStopRadius)
        //{
        //    this.transform.position = target.position;
        //}
        
    }
    public void TakeDamage(float damage)
    {

    }
}
