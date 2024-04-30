using UnityEngine;

public class Player : MonoBehaviour
{
    public Health Health { get; private set; }
    public Level Level  { get; private set; }

    public void Initialize()
    {
        Health = new Health(50);
        Level = new Level();
    }

    public void InvokeParams()
    {
        Health.InvokeChanged();
        Level.InvokeChanged();
    }

    public void Restart()
    {
        Health.Restart();
        Level.Restart();
    }
}
