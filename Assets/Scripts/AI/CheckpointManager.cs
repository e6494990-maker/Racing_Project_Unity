using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] Checkpoint[] checkpoints;
    [SerializeField] ObjectAiMovment[] AIcars;
    public Checkpoint[] Checkpoints => checkpoints;
    private int curPlayerCheckpoint;
    private int nextPlayerCheckpoint;
    private int circleCounter;
    [SerializeField] private TMP_Text place;


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
        Debug.Log("Current P checkpoint: " + curPlayerCheckpoint);
        Debug.Log("Current P circle: " + circleCounter);

        //Выводить в консоль текущий чекпоинт игрока, расстояние до следующего чекпоинта, круг игрока в консоль или на экран
    }
    private void Update()
    {
        int playerplace = 1;
        for(int i = 0; i < AIcars.Length; i++)
        {
            if (AIcars[i].CircleCounter > circleCounter)
            {
                playerplace++;
            }
            else if (AIcars[i].CircleCounter == circleCounter)
            {
                if (AIcars[i].CurCheckPoint > curPlayerCheckpoint)
                {
                    playerplace++;
                }
            }
        }
        Debug.Log(playerplace);
        place.text = playerplace.ToString();
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
