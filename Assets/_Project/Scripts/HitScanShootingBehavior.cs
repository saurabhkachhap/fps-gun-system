using UnityEngine;

[CreateAssetMenu(fileName = "Hit Scan", menuName = "Scriptable Objects/Shooting/Hitscan")]
public class HitScanShootingBehavior : ScriptableObject, IShootingBehavior
{
    [SerializeField] private GameObject decalPrefab;

    public void Shoot(Vector3 origin, Vector3 direction, GunData data)
    {
        Ray ray = new Ray(origin, direction.normalized);
        if(Physics.Raycast(ray, out var hitInfo, data.Range, data.LayerMask))
        {
            var position = hitInfo.point;
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
            var offset = 0.01f * hitInfo.normal;
            Instantiate(decalPrefab, position + offset, rotation);
        }
    }
}
