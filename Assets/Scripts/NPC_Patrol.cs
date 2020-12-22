using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Patrol : MonoBehaviour
{
    public float speed;
    public float waiTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomspot;

    // Start is called before the first frame update
    void Start()
    {
        randomspot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        lookAtTarget();
        Vector3 myTarget = transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomspot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomspot].position) < 0.2f)
        {
            if (waiTime <= 0)
            {
                randomspot = Random.Range(0, moveSpots.Length);
            }
            else
            {
                waiTime -= Time.deltaTime;
            }
        }
    }

    void lookAtTarget()
    {
        Vector3 direction = moveSpots[randomspot].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
