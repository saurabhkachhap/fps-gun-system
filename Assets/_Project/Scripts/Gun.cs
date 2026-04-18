using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private int ammoCount;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ScriptableObject shootingBehaviorAsset;
    [SerializeField] private RecoilData recoilDataAsset;
    [SerializeField] private float recoilResetDelay = 0.2f;
    [SerializeField] private CameraController cameraController;

    private bool ads;
    private IShootingBehavior shootingBehavior;
    private IRecoilBehavior recoilBehavior;
    private ISpreadBehavior spreadBehavior;
    private float lastFireTime;
    private float lastShotTime;
    private bool hasReset;

    private void Awake()
    {
        shootingBehavior = shootingBehaviorAsset as IShootingBehavior;
        if (shootingBehavior is null)
            Debug.LogError("Invalid shooting behavior");

        recoilBehavior = recoilDataAsset.CreateBehavior();
        cameraController.SetRecoverySpeed(recoilDataAsset.recoverySpeed);
        spreadBehavior = new SimpleSpreadBehavior();
    }
    
    public void Fire()
    {
        if (Time.time < lastFireTime) return;
        lastFireTime = Time.time + gunData.FireRate;

        lastShotTime = Time.time;
        hasReset = false;

        cameraController.SetFiring(true);

        // 🎯 bullet recoil (pattern)
        Vector3 direction = cameraTransform.forward;
        Quaternion recoilRotation = recoilBehavior.GetRotation();
        direction = recoilRotation * direction;

        shootingBehavior.Shoot(cameraTransform.position, direction, gunData);
        Debug.DrawRay(cameraTransform.position, direction);

        recoilBehavior.ApplyRecoil();

        // 🎥 camera recoil (visual)
        Vector2 recoil = recoilBehavior.GetRecoil();
        cameraController.AddRecoil(recoil);//👍
    }

    private void Update()
    {
        if (Time.time - lastShotTime > recoilResetDelay)
        {
            cameraController.SetFiring(false);

            if (!hasReset)
            {
                recoilBehavior.Reset();
                hasReset = true;
            }
        }
    }
}
