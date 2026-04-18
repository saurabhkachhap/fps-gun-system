using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Scriptable Objects/GunData")]
[System.Serializable]
public class GunData : ScriptableObject
{
    [field:SerializeField] public float Range { get; private set; }
    [field:SerializeField] public LayerMask LayerMask { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float SpreadAmount { get; private set; }

}
