using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BillboardText : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 offset;
    private float objectHeight;
    private float padding = 0.1f; //Space between object and text

    private Transform mainCameraTransform;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;

        // Get the height of the target object
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            objectHeight = targetRenderer.bounds.size.y;
        }
        else
        {
            Debug.LogWarning("Target object does not have a Renderer component.  Defaulting height to 1.", targetObject);
            objectHeight = 1f; // Default if no renderer is found
        }
        //Set the offset
        offset = new Vector3(0, objectHeight+padding, 0);
    }

    void LateUpdate()
    {
        //Set loaction to object
        if (targetObject != null)
        {
            transform.position = targetObject.position + offset;
        }
        // Make the text face the camera
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
                         mainCameraTransform.rotation * Vector3.up);
    }
}
