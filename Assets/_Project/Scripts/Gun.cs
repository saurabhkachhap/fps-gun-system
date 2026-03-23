using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private int ammoCount;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ScriptableObject shootingBehaviorAsset;

    private bool ads;
    private IShootingBehavior shootingBehavior;
    //private ISpreadBehavior spreadBehavior;
    //private IRecoilBehavior recoilBehavior;

    private void Awake()
    {
        shootingBehavior = shootingBehaviorAsset as IShootingBehavior;
        if (shootingBehavior is null)
            Debug.LogError("Invalid shooting behavior");
    }

    public void Fire()
    {
        Vector3 direction = cameraTransform.forward;

        //direction += recoilBehavior.GetOffset();

        //direction = spreadBehavior.GetFinalDirection(direction, gunData);

        shootingBehavior.Shoot(muzzleTransform.position, direction, gunData);
    }
}
