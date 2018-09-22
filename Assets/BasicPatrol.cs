using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    private NavMeshAgent navMeshAgent;
    private int patrolPointIndex;
    private float proximityBeforeChangeDestination = 0.5f;

    // Use this for initialization
    void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        
        this.navMeshAgent.updatePosition = true;
        this.navMeshAgent.updateRotation = true;
        this.patrolPointIndex = this.patrolPoints.Length - 1;
        this.SetNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.navMeshAgent.pathPending && this.navMeshAgent.remainingDistance < this.proximityBeforeChangeDestination)
        {
            this.SetNextDestination();
        }
    }

    private void SetNextDestination()
    {
        this.navMeshAgent.SetDestination(this.patrolPoints[this.patrolPointIndex].position);
        this.patrolPointIndex = (this.patrolPointIndex + 1) % this.patrolPoints.Length;
    }
}
