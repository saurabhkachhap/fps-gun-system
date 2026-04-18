using UnityEngine;

public class SimpleRecoilBehavior : IRecoilBehavior
{
    private SimpleRecoilData data;

    private Vector2 currentRecoil;

    public SimpleRecoilBehavior(RecoilData data)
    { 
        this.data = data as SimpleRecoilData; 
    }

    public void ApplyRecoil()
    {
        float x = Random.Range(-data.recoil.x, data.recoil.x);
        float y = data.recoil.y;

        currentRecoil += new Vector2(x, y);
    }

    public Vector2 GetRecoil()
    {
        throw new System.NotImplementedException();
    }

    public Quaternion GetRotation()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        
    }

    public void UpdateRecovery(float deltaTime)
    {
        currentRecoil = Vector2.Lerp(currentRecoil, Vector2.zero, deltaTime * data.recoverySpeed);
    }
}
