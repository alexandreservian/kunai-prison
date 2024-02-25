using UnityEngine.SceneManagement;
using UnityEngine;

public class LimitToDie : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
