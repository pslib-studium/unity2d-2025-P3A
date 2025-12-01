using TMPro;
using UnityEngine;

public class ItemsController : MonoBehaviour
{

    [SerializeField] bool holdingPickupItem = false;
    [SerializeField] int collectedItems = 0;
    [SerializeField] TMP_Text deliveredScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Vehicle Triggered with " + other.gameObject.name);
        if (other.CompareTag("pickup") && !holdingPickupItem)
        {
            Destroy(other.gameObject, 0.5f);
            holdingPickupItem = true;
            this.GetComponent<ParticleSystem>().Play();
        }
        if (other.CompareTag("customer") && holdingPickupItem)
        {
            holdingPickupItem = false;
            collectedItems += 1;
            Destroy(other.gameObject, 1f);
            deliveredScore.text = "Delivered: " + collectedItems.ToString();
            this.GetComponent<ParticleSystem>().Stop();
        }
    }
}
