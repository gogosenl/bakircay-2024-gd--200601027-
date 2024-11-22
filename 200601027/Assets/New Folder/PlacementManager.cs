using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject placedObject; // Placement Area'ya yerleþtirilen obje

    public float forceMagnitude = 100f; // Kuvvetin büyüklüðü

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            if (placedObject == null)
            {
                // Placement Area boþsa objeyi yerleþtir
                placedObject = other.gameObject;
                placedObject.transform.position = transform.position; // Placement Area'ya hizala
                placedObject.GetComponent<Rigidbody>().isKinematic = true; // Obje sabit hale gelsin
            }
            else
            {
                // Placement Area doluysa gelen objeyi fýrlat
                Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
                if (otherRigidbody != null)
                {
                    // Objenin Rigidbody'sine bir kuvvet uygula
                    Vector3 direction = (other.transform.position - transform.position).normalized; // Dýþarýya doðru yön
                    otherRigidbody.AddForce(direction * forceMagnitude);
                }
            }
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
