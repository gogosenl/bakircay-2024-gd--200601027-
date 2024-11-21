using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject placedObject;

    void OnTriggerEnter(Collider other)
    {
        if (placedObject == null && other.CompareTag("Draggable"))
        {
            placedObject = other.gameObject;
            other.transform.position = transform.position; // Objeyi merkeze çek
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == placedObject)
        {
            placedObject = null;
        }
    }
}
