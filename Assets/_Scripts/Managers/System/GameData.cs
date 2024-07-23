using System;

[Serializable]

public struct GameData
{
    private long money;

    public long Money
    {
        get { return money; }
        set { money = value; }
    }

    private int star;

    public int Star
    {
        get { return star; }
        set { star = value; }
    }

    private int gem;

    public int Gem
    {
        get { return gem; }
        set { gem = value; }
    }
}
