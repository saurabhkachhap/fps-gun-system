using UnityEngine;

public interface IRecoilBehavior
{
    void ApplyRecoil();
    void UpdateRecovery(float deltaTime);
    Vector3 GetOffset();
  
}
