using UnityEngine;

[CreateAssetMenu(fileName = "Pattern RecoilData", menuName = "Scriptable Objects/Recoil/Pattern")]
public class PatternRecoilData : RecoilData
{
    [field: SerializeField] public Vector2[] pattern { get; private set; }

    public override IRecoilBehavior CreateBehavior()
    {
        return new PatternRecoilBehavior(this);
    }
}