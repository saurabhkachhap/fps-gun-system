using UnityEngine;

public abstract class RecoilData : ScriptableObject
{  
    [field: SerializeField] public float recoverySpeed { get; private set;}
    public abstract IRecoilBehavior CreateBehavior();
}
