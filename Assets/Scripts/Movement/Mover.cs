﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] float maxSpeed = 6f;
        Health health;
        NavMeshAgent navMeshAgent;
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction){
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction){
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction); //Clamp values between 0 and 1.
            navMeshAgent.isStopped = false;
        }

        public void Cancel(){
            navMeshAgent.isStopped = true;
        }
        
        private void UpdateAnimator(){
            Vector3 velocity = navMeshAgent.velocity; //Global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); //Local velocity
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
