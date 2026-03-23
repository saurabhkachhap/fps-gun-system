using UnityEngine;

public interface IShootingBehavior
{
    void Shoot(Vector3 origin, Vector3 direction, GunData data);    
}
