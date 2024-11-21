using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject placedObject; // Yerleþtirilen obje

    void OnTriggerEnter(Collider other)
    {
        if (placedObject == null && other.CompareTag("Draggable"))
        {
            placedObject = other.gameObject; // Obje yerleþtirildi
            placedObject.transform.position = transform.position; // Placement Area'ya hizala
            placedObject.GetComponent<Rigidbody>().isKinematic = true; // Obje artýk hareket etmesin
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == placedObject)
        {
            placedObject.GetComponent<Rigidbody>().isKinematic = false; // Obje hareket edebilir hale gelsin
            placedObject = null; // Placement Area boþaltýldý
        }
    }
}
