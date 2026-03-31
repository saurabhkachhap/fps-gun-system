using UnityEngine;

[CreateAssetMenu(fileName = "Simple RecoilData", menuName = "Scriptable Objects/Recoil/Simple")]
public class RecoilData : ScriptableObject
{
    [field: SerializeField] public Vector2 recoil {get; private set;}
    [field: SerializeField] public float recoverySpeed { get; private set;}
}
