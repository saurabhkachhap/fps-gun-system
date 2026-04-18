using UnityEngine;

public interface ISpreadBehavior
{
    Vector2 GetFinalDirection(Vector3 direction, GunData data);
}
