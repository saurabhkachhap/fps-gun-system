using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private LayerMask layerMask;

    public void Initialize(Vector3 direction, float speed, LayerMask layerMask)
    {
        this.direction = direction.normalized;
        this.speed = speed;
        this.layerMask = layerMask;
    }

    void Update()
    {
        var distance = speed * Time.deltaTime;
        Ray ray = new Ray(transform.position, direction);
        if(Physics.Raycast(ray, out var hitInfo, distance, layerMask))
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += direction * distance;
        }
        
    }
}
