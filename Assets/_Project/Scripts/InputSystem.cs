using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Gun gun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gun.Fire();
    }
}
