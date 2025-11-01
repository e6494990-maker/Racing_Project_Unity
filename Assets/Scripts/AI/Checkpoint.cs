using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private int ind;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarMovement cm))
        {
            CheckpointManager.Instance.GetPlayerCheckpoint(ind);
        }
    }
    public void SetIndex(int index)
    {
        ind = index;
    }
    
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
