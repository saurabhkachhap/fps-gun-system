using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float sensitivity = 100f;
    float recoilRecoverySpeed = 1f;

    float yaw;
    float pitch;

    float recoilYaw;
    float recoilPitch;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AddRecoil(Vector2 recoil)
    {
        recoilYaw += recoil.x;
        recoilPitch += recoil.y;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        Debug.Log(mouseX);
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yaw += mouseX; 
        pitch -= mouseY;

        recoilPitch = Mathf.Lerp(recoilPitch, 0f, recoilRecoverySpeed * Time.deltaTime);
        recoilYaw = Mathf.Lerp(recoilYaw, 0f, recoilRecoverySpeed * Time.deltaTime);

        float finalPitch = pitch - recoilPitch;
        float finalYaw = yaw + recoilYaw;

        finalPitch = Mathf.Clamp(finalPitch, -80f, 80f);

        playerBody.rotation = Quaternion.Euler(0f, finalYaw, 0f);
        transform.localRotation = Quaternion.Euler(finalPitch, 0f, 0f);

    }

    internal void SetRecoverySpeed(float recoverySpeed)
    {
        recoilRecoverySpeed = recoverySpeed;
    }
}
