using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectAiMovment : MonoBehaviour
    
{
    NavMeshAgent navagent;
    // Start is called before the first frame update
    void Start()
    {
        navagent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
