using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("Player has crashed!");
            Invoke(nameof(ReloadScene), 1f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(0);
    }
}
