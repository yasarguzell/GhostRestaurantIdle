using System;

[Serializable]
public struct RoomData
{
    private int level;

    public int Level
    {
        get { return level; }
        set { level++; }
    }

    private int worker;

    public int Worker
    {
        get { return worker; }
        set { worker++; }
    }

    private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed += value; }
    }

    private float workSpeed;

    public float WorkSpeed
    {
        get { return workSpeed; }
        set { workSpeed += value; }
    }
}
