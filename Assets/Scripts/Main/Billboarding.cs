using UnityEngine;
using TMPro; 

public class BillboardText : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Make the text face the camera
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
                         mainCameraTransform.rotation * Vector3.up);
    }
}
