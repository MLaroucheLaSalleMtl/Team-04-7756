﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
   // [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    //[RequireComponent(typeof(ThirdPersonEnemy))]
    public class AIEnemyControl : MonoBehaviour
    {
        private UnityEngine.AI.NavMeshAgent agent;// { get; private set; }             // the navmesh agent required for the path finding
        private ThirdPersonEnemy character; //{ get; private set; } // the character we are controlling
        [SerializeField] Transform target;                                    // target to aim for


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonEnemy>();

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
            this.target = target;
        }
    }
}