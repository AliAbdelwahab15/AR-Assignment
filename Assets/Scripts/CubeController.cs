using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    public AudioSource buzzAudio;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void ReturnToOriginal()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = false;
            rb.useGravity = false;
        }

        if (buzzAudio != null)
        {
            buzzAudio.Play();
        }
    }
}
