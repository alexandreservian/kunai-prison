using UnityEngine;

public class DirectionKunai : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField] private Transform ninja;
    [SerializeField] private GameObject kunai;
    [SerializeField] private Transform kunaiOrigins;
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

        if(Input.GetMouseButtonDown(0) && !kunai.activeSelf) {
            kunai.SetActive(true);
            kunai.transform.position = kunaiOrigins.position;
        }

        if(Input.GetMouseButtonDown(1) && kunai.activeSelf) {
            kunai.SetActive(false);
            ninja.position = kunai.transform.position;
        }
    }
}
   