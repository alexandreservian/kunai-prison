using UnityEngine;

public class Kunai : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;

    void OnEnable()
    {
        mainCamera = Camera.main;
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var direction = mousePos - transform.position;
        var rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        var rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
    }

    void Update()
    {
        
    }
}
