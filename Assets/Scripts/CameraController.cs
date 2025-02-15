using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float sensitivity = 2f;

    private Vector3 offset;
    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        offset = new Vector3(0, 2, -distance);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivity;
            currentY -= Input.GetAxis("Mouse Y") * sensitivity;
            currentY = Mathf.Clamp(currentY, -40f, 80f);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset.normalized * distance;
        transform.position = desiredPosition;
        transform.LookAt(target.position);
    }
}
