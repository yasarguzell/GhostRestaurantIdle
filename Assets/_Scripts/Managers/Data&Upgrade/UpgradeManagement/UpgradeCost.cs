using System.Collections.Generic;
using UnityEngine;

public class UpgradeCost : MonoBehaviour
{
    public Dictionary<int, float> CostValuesX = new(){
        {0, 100},
        {1, 200},
        {2, 300},
        {3, 400},
        {4, 500},
    
    };
    public int CostValueXIndex = 0;

    public Dictionary<int, float> CostValuesY = new(){
        {0, 12},
        {1, 24},
        {2, 36},
        {3, 48},
        {4, 60}
    };
    public int CostValueYIndex = 0;

    public Dictionary<int, float> CostValuesZ = new(){
        {0, 15},
        {1, 30},
        {2, 45},
        {3, 60},
        {4, 75}
    };
    public int CostValueZIndex = 0;

    public Dictionary<int, float> CostValuesA = new(){
        {0, 20},
        {1, 40},
        {2, 60},
        {3, 80},
        {4, 100}
    };
    public int CostValueAIndex = 0;

    public Dictionary<int, float> CostValuesB = new(){
        {0, 35},
        {1, 70},
        {2, 105},
        {3, 140},
        {4, 175}
    };
    public int CostValueBIndex = 0;
}
