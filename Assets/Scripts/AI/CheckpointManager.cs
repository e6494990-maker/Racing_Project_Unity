using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
   [SerializeField] Checkpoint[] checkpoints;
    public Checkpoint[] Checkpoints => checkpoints;

    public static CheckpointManager Instance;

    void Awake()
    {
        Instance = this;
    }
 
    void Update()
    {
        
    }
}
