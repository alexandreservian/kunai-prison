using System;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    [Header("Configuração da kunai")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float limitHorizontal = 1;
    [SerializeField] private float limitVertical = 1;
    private Vector2 screenBounds;

    void OnEnable()
    {
        mainCamera = Camera.main;
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var direction = mousePos - transform.position;
        var rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        var rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x ||
            transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Obstacle")) {
            gameObject.SetActive(false);
        }
    }
    

}
