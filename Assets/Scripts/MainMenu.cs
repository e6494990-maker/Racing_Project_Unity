using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public Canvas MenuCanvas;
    [SerializeField] public Canvas WorkShopCanvas;
    [SerializeField] public Canvas LevelChooseCanvas;

    private void Start()
    {
        WorkShopCanvas.enabled = false;
        LevelChooseCanvas.enabled = false;
    }
    public void MenuCanvasSwitcher(bool mySwitch)
    {
        MenuCanvas.enabled = mySwitch;
    }
    public void WorkCanvasSwitcher(bool mySwitch)
    {
        WorkShopCanvas.enabled = mySwitch;
    }
    public void LevelCanvasSwitcher(bool mySwitch)
    {
        LevelChooseCanvas.enabled = mySwitch;
    }
    

}


