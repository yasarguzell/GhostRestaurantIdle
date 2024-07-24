using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public struct RoomData
{
    [Header("Lounge")]
    public float waiterMoveSpeed;
    public int tipFrequency;
    public int waiterNumber;
    public int tableSize;

    [Header("Kitchen")]
    public float chefCookSpeed;
    public float porterMoveSpeed;
    public int porterNumber;
    public int productQuality;

    [Header("Scullery")]
    public float scullionMoveSpeed;
    public float dishwasherSpeed;
    public int dishwasherNumber;
    public int scullionNumber;

}
