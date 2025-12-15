using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void BeginGame()
    {
         Time.timeScale = 1f;
         gameObject.SetActive(false);
    }
}
