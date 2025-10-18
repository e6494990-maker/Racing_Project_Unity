using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectAiMovment : MonoBehaviour  
{
    NavMeshAgent navagent;
    private int curCheckPoint;
    private int nextCheckPoint;
    private int circlecounter;
    
    void Start()
    {
        nextCheckPoint = 0;
        navagent = GetComponent<NavMeshAgent>();
        curCheckPoint = CheckpointManager.Instance.Checkpoints.Length - 1;
        circlecounter = 1;
    }

    
    void Update()
    {
        navagent.SetDestination(CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position);
        if (Vector3.Distance(transform.position, CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position) < 6)
        {
            curCheckPoint = nextCheckPoint;
            if(curCheckPoint == CheckpointManager.Instance.Checkpoints.Length - 1)
            {
                nextCheckPoint = 0;
                circlecounter += 1;
            }
            else
            {
                nextCheckPoint = curCheckPoint + 1;
            }
            Debug.Log("Текущий чекпоинт: " + curCheckPoint);
            Debug.Log("Текущий круг: " + circlecounter);
        }
    }
}
