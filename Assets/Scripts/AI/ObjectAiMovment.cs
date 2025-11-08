using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectAiMovment : MonoBehaviour  
{
    NavMeshAgent navagent;
    private int curCheckPoint;
    private int nextCheckPoint;
    private int circleCounter;

    public int CurCheckPoint => curCheckPoint;
    public int NextCheckPoint => nextCheckPoint;
    public int CircleCounter => circleCounter;



    void Start()
    {
        
        nextCheckPoint = 0;
        navagent = GetComponent<NavMeshAgent>();
        curCheckPoint = CheckpointManager.Instance.Checkpoints.Length - 1;
        circleCounter = 1;
    }

    
    void Update()
    {
        if (!TraficLights.Instance.TraficControll)
        {
            return;
        }
        navagent.SetDestination(CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position);
        if (Vector3.Distance(transform.position, CheckpointManager.Instance.Checkpoints[nextCheckPoint].transform.position) < 20)
        {
            curCheckPoint = nextCheckPoint;
            if(curCheckPoint == CheckpointManager.Instance.Checkpoints.Length - 1)
            {
                nextCheckPoint = 0;
                circleCounter += 1;
            }
            else
            {
                nextCheckPoint = curCheckPoint + 1;
            }
            Debug.Log("Current checkpoint: " + curCheckPoint);
            Debug.Log("Current circle: " + circleCounter);
        }
    }
}
