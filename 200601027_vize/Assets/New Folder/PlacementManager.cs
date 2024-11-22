using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject placedObject; // Placement Area'ya yerle�tirilen obje

    public float forceMagnitude = 100f; // Kuvvetin b�y�kl���

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            if (placedObject == null)
            {
                // Placement Area bo�sa objeyi yerle�tir
                placedObject = other.gameObject;
                placedObject.transform.position = transform.position; // Placement Area'ya hizala
                placedObject.GetComponent<Rigidbody>().isKinematic = true; // Obje sabit hale gelsin
            }
            else
            {
                // Placement Area doluysa gelen objeyi f�rlat
                Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
                if (otherRigidbody != null)
                {
                    // Objenin Rigidbody'sine bir kuvvet uygula
                    Vector3 direction = (other.transform.position - transform.position).normalized; // D��ar�ya do�ru y�n
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
            placedObject = null; // Placement Area bo�alt�ld�
        }
    }
}
