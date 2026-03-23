using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.right * -mouseY);
    }
}
