using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject placedObject; // Yerle�tirilen obje

    void OnTriggerEnter(Collider other)
    {
        if (placedObject == null && other.CompareTag("Draggable"))
        {
            placedObject = other.gameObject; // Obje yerle�tirildi
            placedObject.transform.position = transform.position; // Placement Area'ya hizala
            placedObject.GetComponent<Rigidbody>().isKinematic = true; // Obje art�k hareket etmesin
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == placedObject)
        {
            placedObject.GetComponent<Rigidbody>().isKinematic = false; // Obje hareket edebilir hale gelsin
            placedObject = null; // Placement Area bo�alt�ld�
        }
    }
}
