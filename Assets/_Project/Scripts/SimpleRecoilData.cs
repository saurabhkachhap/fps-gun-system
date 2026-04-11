using UnityEngine;

[CreateAssetMenu(fileName = "Simple RecoilData", menuName = "Scriptable Objects/Recoil/Simple")]
public class SimpleRecoilData : RecoilData
{
    [field: SerializeField] public Vector2 recoil { get; private set; }

    public override IRecoilBehavior CreateBehavior()
    {
        return new SimpleRecoilBehavior(this);
    }
}
