using UnityEngine;

public class DirectionKunai : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var rotation = mousePos - transform.position;
        var rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
   