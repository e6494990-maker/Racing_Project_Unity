using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CheckpointManager : MonoBehaviour
{
   [SerializeField] Checkpoint[] checkpoints;
    public Checkpoint[] Checkpoints => checkpoints;
    private int curPlayerCheckpoint;
    private int nextPlayerCheckpoint;
    private int circleCounter;


    public static CheckpointManager Instance;

    public void GetPlayerCheckpoint(int ind)
    {
        if(nextPlayerCheckpoint == ind)
        {
            curPlayerCheckpoint = ind;
            if(curPlayerCheckpoint == CheckpointManager.Instance.Checkpoints.Length - 1)
            {
                nextPlayerCheckpoint = 0;
                circleCounter += 1;
            }
            else
            {
                nextPlayerCheckpoint += 1;
            }
        }
        //Выводить в консоль текущий чекпоинт игрока, расстояние до следующего чекпоинта, круг игрока в консоль или на экран
    }
    

    void Awake()
    {
        Instance = this;
    }
 
    void Start()
    {
        circleCounter = 1;
        nextPlayerCheckpoint = 0;
        for(int i = 0; i < Checkpoints.Length; i++)
        {
            Checkpoints[i].SetIndex(i);
        }
    }
}
