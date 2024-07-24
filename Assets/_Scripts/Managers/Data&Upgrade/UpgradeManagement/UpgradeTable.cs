using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    public Dictionary<int, float> valuesX = new(){
        {1, 5},
        {2, 10},
        {3, 15},
        {4, 20},
        {5, 25}
    };
    public int valueXIndex = 0;

    public Dictionary<int, float> valuesY = new(){
        {1, 12},
        {2, 24},
        {3, 36},
        {4, 48},
        {5, 60}
    };
    public int valueYIndex = 0;

    public Dictionary<int, float> valuesZ = new(){
        {1, 15},
        {2, 30},
        {3, 45},
        {4, 60},
        {5, 75}
    };
    public int valueZIndex = 0;

    public Dictionary<int, float> valuesA = new(){
        {1, 20},
        {2, 40},
        {3, 60},
        {4, 80},
        {5, 100}
    };
    public int valueAIndex = 0;

    public Dictionary<int, float> valuesB = new(){
        {1, 35},
        {2, 70},
        {3, 105},
        {4, 140},
        {5, 175}
    };
    public int valueBIndex = 0;
}
