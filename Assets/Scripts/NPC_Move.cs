using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPC_Move : MonoBehaviour
{
    private int i;
    public ThirdPersonCharacter character;
    NavMeshAgent agent;

    [SerializeField]
    List<Transform> destinationCheckpoints;


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

            SetDestination();
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            i++;

            SetDestination();
        }
    }

    /// <summary>
    /// Method for NPC movement
    /// </summary>
    private void SetDestination()
    {
        if (destinationCheckpoints != null)
        {
            Vector3 targetVector = destinationCheckpoints[i].transform.position;
            //agent.Move(targetVector);
            agent.SetDestination(targetVector);
        }
    }
}
