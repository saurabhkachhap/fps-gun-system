using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Scriptable Objects/GunData")]
public class GunData : ScriptableObject
{
    [field:SerializeField] public float Range { get; private set; }
    [field:SerializeField] public LayerMask LayerMask { get; private set; }
    [field: SerializeField] public float fireRate { get; private set; }

}
