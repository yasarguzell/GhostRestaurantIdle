using System.Collections.Generic;
using UnityEngine;

public class UpgradeCost : MonoBehaviour
{
    public Dictionary<int, float> CostChefCookSpeedUpgrade = new(){
        {0, 100},
        {1, 200},
        {2, 300},
        {3, 400},
        {4, 500},

    };
    public int CostChefCookSpeedIndex = 0;

    public Dictionary<int, float> CostWaitersUpgradeSpeed = new(){
        {0, 12},
        {1, 24},
        {2, 36},
        {3, 48},
        {4, 60}
    };
    public int CostWaitersUpgradeIndex = 0;
    public Dictionary<int, float> CostIncreaseTable = new(){
        {0, 20},
        {1, 40},
        {2, 60},
        {3, 80},
        {4, 100}
    };
    public int CostIncreaseTableIndex = 0;

    public Dictionary<int, float> CostValuesUpgradeChefMoveSpeed = new(){
        {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175}
    };
    public int CostUpgradeCMoveSpeedIndex = 0;

    public Dictionary<int, float> CostHiringWaiters = new(){
        {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175},
        {5, 200},
        {6, 250}
    };
    public int CostHiringWaitersIndex = 0;
    public Dictionary<int, float> CostHireChef = new(){
        {0, 100},
        {1, 200},
        {2, 300},
        {3, 400},
        {4, 500},
        {5, 600},
        {6, 700}
    };
    public int CostHireChefIndex = 0;
    public Dictionary<int, float> CostValueUpgradeSpeedWashingWorker = new(){
         {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175},
        {5, 200},

    };
    public int CostValueUpgradeSpeedWashingWorkerIndex = 0;
    public Dictionary<int, float> CostValueUpgradeSpeedWashingDishWasher = new(){
         {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175},
        {5, 200},
    };
    public int CostValueUpgradeSpeedWashingDishWasherIndex = 0;
    public Dictionary<int, float> CostUpgradeDishwasherRoom = new(){
        {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175},
        {5, 200},
        {6, 225},
    };
    public int CostUpgradeDishwasherRoomIndex = 0;
}
