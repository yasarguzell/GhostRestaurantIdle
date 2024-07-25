using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    // hire dışındaki değerler değişebilir ekleme de haber verin
    public Dictionary<int, float> valueChefCookSpeedUpgrade = new(){
        {1, 5},
        {2, 10},
        {3, 15},
        {4, 20},
        {5, 25}
    };
    public int IndexChefCookSpeedUpgrade = 0;
    public Dictionary<int, float> valueWaitersUpgradeSpeed = new(){
        {1, 12},
        {2, 24},
        {3, 36},
        {4, 48},
        {5, 60}
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
        {1, 35},
        {2, 70},
        {3, 105},
        {4, 140},
        {5, 175}
    };
    public int valueUpgradeChefMoveSpeedIndex = 0;
      public Dictionary<int, float> ValueUpgradeSpeedWashingWorker = new(){
        {1, 35},
        {2, 70},
        {3, 105},
        {4, 140},
        {5, 175},
    };
    public int ValueUpgradeSpeedWashingWorkerIndex = 0;
     public Dictionary<int, float> ValueUpgradeSpeedWashingDishWash = new(){
       {1, 35},
        {2, 70},
        {3, 105},
        {4, 140},
        {5, 175}

    };
    public int ValueUpgradeSpeedWashingDishWashIndex = 0;
     
}


