using UnityEngine;

internal class PatternRecoilBehavior : IRecoilBehavior
{
    private PatternRecoilData data;
    private int currentIndex = 0;
    private Vector2 currentRecoil;
    private Vector2 lastRecoil;

    public PatternRecoilBehavior(RecoilData data)
    {
        this.data = data as PatternRecoilData;
        currentRecoil = Vector2.zero;
    }

    public void ApplyRecoil()
    {
        currentRecoil += data.pattern[currentIndex % data.pattern.Length];
        currentIndex++;
    }

    public Quaternion GetRotation()
    {
        var offset = GetRecoilOffset();
        return Quaternion.Euler(-offset.y, offset.x, 0f);
    }

    public Vector2 GetRecoil()        // for camera
    {
        return GetRecoilOffset();
    }

    private Vector2 GetRecoilOffset()
    {
        var offset = currentRecoil - lastRecoil;
        lastRecoil = currentRecoil;
        return offset;
    }

    public void Reset()
    {
        currentIndex = 0;
        currentRecoil = Vector2.zero;
        lastRecoil = Vector2.zero;
    }
}