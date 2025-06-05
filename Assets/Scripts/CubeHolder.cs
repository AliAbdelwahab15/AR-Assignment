using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeHolder : MonoBehaviour
{
    public string acceptedTag;

    // Prevents multiple snaps
    private bool isSolved = false;

    private void OnTriggerStay(Collider other)
    {
        if (isSolved)
            return;

        if (!other.CompareTag(acceptedTag))
            return;

        XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();

        if (grab != null && grab.isSelected)
            return;

        isSolved = true;

        other.transform.position = transform.position;
        other.transform.rotation = transform.rotation;

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (grab != null)
        {
            grab.enabled = false;
        }

        SolvePuzzle manager = FindObjectOfType<SolvePuzzle>();
        if (manager != null)
        {
            manager.RegisterCorrectPlacement();
        }

    }
}
