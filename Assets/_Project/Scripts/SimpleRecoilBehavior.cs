using UnityEngine;

public class SimpleRecoilBehavior : IRecoilBehavior
{
    private RecoilData data;

    private Vector2 currentRecoil;

    public SimpleRecoilBehavior(RecoilData data)
    { 
        this.data = data; 
    }

    public void ApplyRecoil()
    {
        float x = Random.Range(-data.recoil.x, data.recoil.x);
        float y = data.recoil.y;

        currentRecoil += new Vector2(x, y);
    }

    public Vector3 GetOffset()
    {
        return new Vector3(currentRecoil.x, currentRecoil.y, 0f);
    }

    public void UpdateRecovery(float deltaTime)
    {
        currentRecoil = Vector2.Lerp(currentRecoil, Vector2.zero, deltaTime * data.recoverySpeed);
    }
}
