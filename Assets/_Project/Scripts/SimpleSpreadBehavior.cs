using UnityEngine;

public class SimpleSpreadBehavior : ISpreadBehavior
{
    public Vector2 GetFinalDirection(Vector3 direction, GunData data)
    {
        var x = Random.Range(-data.SpreadAmount, data.SpreadAmount);
        var y = Random.Range(-data.SpreadAmount, data.SpreadAmount);

        var spread = new Vector3(x, y, 0);
        return (direction + spread).normalized;
    }
}
