using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectAiMovment : MonoBehaviour  
{
    NavMeshAgent navagent;
    private int curCheckPoint;
    private int nextCheckPoint;
    
    void Start()
    {
        nextCheckPoint = 0;
        navagent = GetComponent<NavMeshAgent>();
        curCheckPoint = CheckpointManager.Instance.Checkpoints.Length - 1;
    }

    
    void Update()
    {
        navagent.SetDestination(CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position);
        if (Vector3.Distance(transform.position, CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position) < 6)
        {

        }
    }
}
