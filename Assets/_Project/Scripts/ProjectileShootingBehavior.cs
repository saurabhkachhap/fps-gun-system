using UnityEngine;

public class ProjectileShootingBehavior : IShootingBehavior
{
    public void Shoot(Vector3 origin, Vector3 direction, GunData data)
    {
        if(data is not ProjectileGunData projectileGunData)
        {
            Debug.LogError("Invalid GunData for ProjectileShootingBehavior");
            return;
        }

        var obj = Object.Instantiate(projectileGunData.projectilePrefab, origin, Quaternion.identity);
        obj.Initialize(direction, projectileGunData.speed, data.LayerMask);
    }
}
