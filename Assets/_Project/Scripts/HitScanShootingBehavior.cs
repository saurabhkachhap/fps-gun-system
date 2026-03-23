using UnityEngine;

[CreateAssetMenu(fileName = "Hit Scan", menuName = "Scriptable Objects/Shooting/Hitscan")]
public class HitScanShootingBehavior : ScriptableObject, IShootingBehavior
{
    public void Shoot(Vector3 origin, Vector3 direction, GunData data)
    {
        Ray ray = new Ray(origin, direction.normalized);
        if(Physics.Raycast(ray, out var hitInfo, data.Range, data.LayerMask))
        {
            Debug.Log(hitInfo.collider.name);
        }
    }
}
