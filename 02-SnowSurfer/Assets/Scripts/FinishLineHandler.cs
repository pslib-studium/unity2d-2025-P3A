using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("Player has reached the finish line!");
            Invoke(nameof(ReloadScene), 1f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(0);
    }
}
