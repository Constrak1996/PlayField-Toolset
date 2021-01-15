using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Move : MonoBehaviour
{
    private int i;
    NavMeshAgent agent;
    private bool done = false;

    

    [SerializeField] Transform checkpoint_1;
    [SerializeField] int waitTime1;
    [SerializeField] Transform checkpoint_2;
    [SerializeField] int waitTime2;
    [SerializeField] bool loop;

    //Checkpoint stuff
    [SerializeField] List<Transform> destinationCheckpoints;

    private void Start()
    {
        agent.updateRotation = false;
    }

    // Start is called before the first frame update
    void Update()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("The nav mesh agent component is null");
        }
        else
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                agent.SetDestination(agent.desiredVelocity);
            }
            else
            {
                agent.Move(Vector3.zero); 
            }

            if (done == false)
            {
                SetDestination();
            }
            else if (done == true)
            {
                Debug.Log("Done");
            }
            
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            other.gameObject.SetActive(false);
            i++;

            if (done == false)
            {
                SetDestination();
            }
            else if (done == true)
            {

            }
        }
    }

    /// <summary>
    /// Method for NPC movement
    /// </summary>
    private void SetDestination()
    {
        
        if(destinationCheckpoints.Count != 0)
        {
            Vector3 targetVector = destinationCheckpoints[i].transform.position;
            agent.SetDestination(targetVector);
        }
        else if(destinationCheckpoints.Count == 0)
        {
            done = true;
        }
    }

    private void LoopingCheckpoint()
    {

    }

    private void WaitCheckpoint()
    {

    }
}
