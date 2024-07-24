using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum WorkerRoom
{
    Lounge,
    Kitchen,
    Scullery
}

[System.Serializable]

public class WorkerData 
{
    public string id;
    public WorkerRoom workerRoom;
    public Vector3 position;
    public Quaternion rotation;
}
