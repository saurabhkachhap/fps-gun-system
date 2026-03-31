using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private int ammoCount;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ScriptableObject shootingBehaviorAsset;
    [SerializeField] private RecoilData recoilDataAsset;
    //[SerializeField] private ScriptableObject recoilBehaviorAsset;

    private bool ads;
    private IShootingBehavior shootingBehavior;
    private IRecoilBehavior recoilBehavior;
    //private ISpreadBehavior spreadBehavior;

    private void Awake()
    {
        shootingBehavior = shootingBehaviorAsset as IShootingBehavior;
        if (shootingBehavior is null)
            Debug.LogError("Invalid shooting behavior");

        recoilBehavior = new SimpleRecoilBehavior(recoilDataAsset);
    }
    //TODO Tile camera with recoil
    public void Fire()
    {
        Vector3 direction = cameraTransform.forward;
        recoilBehavior.ApplyRecoil();
        direction += recoilBehavior.GetOffset();
        
        //direction = spreadBehavior.GetFinalDirection(direction, gunData);

        shootingBehavior.Shoot(muzzleTransform.position, direction, gunData);
    }

    private void Update()
    {
        recoilBehavior.UpdateRecovery(Time.deltaTime);
    }
}
