using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    // hire dışındaki değerler değişebilir ekleme de haber verin
    public Dictionary<int, float> valueChefCookSpeedUpgrade = new(){
         {1, -0.25f},
        {2, -0.20f},
        {3, -0.03f},
        {4, -0.02f},
        {5, -0.01f}
    };
    public int IndexChefCookSpeedUpgrade = 0;
    public Dictionary<int, float> valueWaitersUpgradeSpeed = new(){
    {1, 0.25f},
        {2, 0.2f},
        {3, 0.15f},
        {4, 0.1f},
        {5, 0.1f}
    };
    public int IndexWaitersUpgradeSpeed = 0;

    public Dictionary<int, float> valueIncreaseTable = new(){
        {1, 1},
        {2, 2},
        {3, 3},
        {4, 4},
        
    };
    public int valueIncreaseTableIndex = 0;
    public Dictionary<int, float> valuesUpgradeChefMoveSpeed = new(){
        {1, 0.25f},
        {2, 0.2f},
        {3, 0.15f},
        {4, 0.1f},
        {5, 0.1f}
    };
    public int valueUpgradeChefMoveSpeedIndex = 0;
      public Dictionary<int, float> ValueUpgradeSpeedWashingWorker = new(){
        {1, 0.25f},
        {2, 0.2f},
        {3, 0.15f},
        {4, 0.1f},
        {5, 0.1f}
    };
    public int ValueUpgradeSpeedWashingWorkerIndex = 0;
     public Dictionary<int, float> ValueUpgradeSpeedWashingDishWash = new(){
       {1, -0.25f},
        {2, -0.20f},
        {3, -0.03f},
        {4, -0.02f},
        {5, -0.01f}

    };
    public int ValueUpgradeSpeedWashingDishWashIndex = 0;
     
}


