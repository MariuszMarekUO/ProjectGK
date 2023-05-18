using System;

[Serializable]
public class Score
{
    public string name;
    public float distance;

    public Score(string name, float distance)
    {
        this.name = name;
        this.distance = distance;
    }
}
