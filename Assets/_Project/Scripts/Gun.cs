using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private int ammoCount;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ScriptableObject shootingBehaviorAsset;
    [SerializeField] private RecoilData recoilDataAsset;
    [SerializeField] private CameraController cameraController;

    private bool ads;
    private IShootingBehavior shootingBehavior;
    private IRecoilBehavior recoilBehavior;
    //private ISpreadBehavior spreadBehavior;
    private float lastFireTime;

    private void Awake()
    {
        shootingBehavior = shootingBehaviorAsset as IShootingBehavior;
        if (shootingBehavior is null)
            Debug.LogError("Invalid shooting behavior");

        recoilBehavior = recoilDataAsset.CreateBehavior();
        cameraController.SetRecoverySpeed(recoilDataAsset.recoverySpeed);
    }
    
    public void Fire()
    {
        if (Time.time < lastFireTime) return;
        lastFireTime = Time.time + gunData.fireRate;
        Vector3 direction = cameraTransform.forward;
        recoilBehavior.ApplyRecoil();
        var offset = recoilBehavior.GetOffset();
        cameraController.AddRecoil(offset);
        //direction = spreadBehavior.GetFinalDirection(direction, gunData);

        shootingBehavior.Shoot(cameraTransform.position, direction, gunData);
    }

    private void Update()
    {
        recoilBehavior.UpdateRecovery(Time.deltaTime);
    }
}
