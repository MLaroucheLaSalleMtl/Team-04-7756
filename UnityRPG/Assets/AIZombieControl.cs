﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonEnemy))]
public class AIZombieControl : MonoBehaviour    
{
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonEnemy character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for
    private Zombie enemy;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonEnemy>();
        enemy = GetComponent<Zombie>();
        agent.updateRotation = false;
        agent.updatePosition = true;
    }


    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }


    public void SetTarget(Transform target)
    {
        if (enemy.currentHealthPoints > 0)
        {
            this.target = target;
        }
        else
        {
            this.target = null;
        }
    }
}
