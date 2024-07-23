using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomUpgradeValues", menuName = "ScriptableObjects/RoomUpgradeValues")]

public class RoomUpgradeValues : ScriptableObject
{
    public Dictionary<float, long> levelUpgrades = new();
    public int levelIndex;

    public Dictionary<float, long> moveSpeedUpgrades = new();
    public int moveSpeedIndex;

    public Dictionary<float, long> workSpeedUpgrades = new();
    public int workSpeedIndex;
}
