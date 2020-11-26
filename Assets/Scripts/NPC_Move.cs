using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Move : MonoBehaviour
{
    private int i;

    [SerializeField]
    //List of destination for NPC
    List<Transform> destinationCheckpoints;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Update()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is null");
        }
        else
        {
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
            navMeshAgent.SetDestination(targetVector);
        }
    }
}
