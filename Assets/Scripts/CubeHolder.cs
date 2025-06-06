using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeHolder : MonoBehaviour
{
    public string acceptedTag;

    private bool isSolved = false;

    private void OnTriggerStay(Collider other)
    {
        if (isSolved)
            return;

        CubeController cube = other.GetComponent<CubeController>();
        if (cube == null)
            return;

        XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
        if (grab != null && grab.isSelected)
            return;

        if (other.CompareTag(acceptedTag))
        {
            isSolved = true;

            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            if (grab != null)
                grab.enabled = false;

            GameWorker manager = FindObjectOfType<GameWorker>();
            if (manager != null)
                manager.RegisterCorrectPlacement();

        }
        else
        {
            cube.ReturnToOriginal();
        }
    }
}
