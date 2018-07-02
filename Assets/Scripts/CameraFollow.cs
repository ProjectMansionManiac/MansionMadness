using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector2 levelTopLeft;
    [SerializeField] private Vector2 levelBottomRight;
    [SerializeField] private float cameraClipOffsetX;
    [SerializeField] private float cameraClipOffsetY;

    public float dampTime = 0.15f;
    public Transform target;

    void LateUpdate()
    {
        if (target)
        {
            Vector3 from = transform.position;
            Vector3 to = target.position;
            to.z = transform.position.z;

            transform.position -= (from - to) * dampTime * Time.deltaTime;
        }

        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, levelTopLeft.x + cameraClipOffsetX, levelBottomRight.x - cameraClipOffsetX),
           Mathf.Clamp(transform.position.y, levelBottomRight.y + cameraClipOffsetY, levelTopLeft.y - cameraClipOffsetY),
           transform.position.z
       );
    }
}
