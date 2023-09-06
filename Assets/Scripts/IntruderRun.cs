using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IntruderRun : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform destination;
    public GameObject runSound;
    public bool started;


    public void ActivateDestination()
    {
        navMeshAgent.SetDestination(destination.position);
        StartCoroutine(Run());
        started = true;
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && started)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    IEnumerator Run()
    {
        yield return new WaitForSeconds(.5f);
        runSound.SetActive(true);
        GetComponent<Animation>().Play("RunForward");

    }
}
