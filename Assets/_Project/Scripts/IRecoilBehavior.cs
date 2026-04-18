using UnityEngine;

public interface IRecoilBehavior
{
    void ApplyRecoil();
    Quaternion GetRotation();
    Vector2 GetRecoil();
    void Reset();
}
