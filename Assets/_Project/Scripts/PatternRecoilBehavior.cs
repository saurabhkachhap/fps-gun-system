using UnityEngine;

internal class PatternRecoilBehavior : IRecoilBehavior
{
    private PatternRecoilData data;
    private int currentIndex = 0;
    private Vector2 currentRecoil;

    public PatternRecoilBehavior(RecoilData data)
    {
        this.data = data as PatternRecoilData;
    }

    public void ApplyRecoil()
    {
        currentRecoil += data.pattern[currentIndex % data.pattern.Length];
        currentIndex++;
    }

    public Vector3 GetOffset()
    {
        return new Vector3(currentRecoil.x, currentRecoil.y, 0f);
    }

    private void ResetRecoil()
    {
        currentIndex = 0;
    }

    public void UpdateRecovery(float deltaTime)
    {
        currentRecoil = Vector2.Lerp(currentRecoil, Vector2.zero, data.recoverySpeed * deltaTime);

        if(currentRecoil == Vector2.zero)
            ResetRecoil();

    }
}