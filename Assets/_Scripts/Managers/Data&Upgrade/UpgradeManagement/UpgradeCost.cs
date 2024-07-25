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
         {0, 100},
        {1, 200},
        {2, 300},
        {3, 400},
        {4, 500},
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
        {0, 100},
        {1, 200},
        {2, 300},
        {3, 400},
        {4, 500},
    };
    public int CostUpgradeCMoveSpeedIndex = 0;

    public Dictionary<int, float> CostHiringWaiters = new(){
        {0, 200},
        {1, 250},
        {2, 400},
        {3, 600},
        {4, 800},
        {5, 1000},
        {6, 2000}
    };
    public int CostHiringWaitersIndex = 0;
    public Dictionary<int, float> CostHireChef = new(){
        {0, 350},
        {1, 400},
        {2, 500},
        {3, 600},
        {4, 800},
        {5, 1000},
        {6, 2000}
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
         {0, 350},
        {1, 400},
        {2, 500},
        {3, 600},
        {4, 800},
        {5, 1000},
        {6, 2000}
    };
    public int CostUpgradeDishwasherRoomIndex = 0;
}
