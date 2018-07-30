using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Vector2 levelTopLeft;
    [SerializeField] public Vector2 levelBottomRight;
    [SerializeField] private float cameraClipOffsetX;
    [SerializeField] private float cameraClipOffsetY;
    float distanceBetweenTargets;
    public float maxDistanceZ, minDistanceZ;

    public float dampTime = 0.15f;
    public Vector3 target;

    public Transform enemyTransform, playerTransform;

    public float maxDistanceToBoss;

    void LateUpdate()
    {
        target.x = (enemyTransform.position.x + playerTransform.position.x) / 2;
        target.y = (enemyTransform.position.y + playerTransform.position.y) / 2;
        if (target != Vector3.zero)
        {
            Vector3 from = transform.position;
            Vector3 to = target;
            to.z = transform.position.z;

            Vector3 connectionVector = enemyTransform.position - playerTransform.position;
            distanceBetweenTargets = Mathf.Sqrt((connectionVector.x * connectionVector.x) + (connectionVector.y * connectionVector.y) + (connectionVector.z * connectionVector.z));

            if (distanceBetweenTargets >= maxDistanceToBoss)
            {
                to = playerTransform.position;
                to.z = transform.position.z;
            }
                


            transform.position -= (from - to) * dampTime * Time.deltaTime;
            //Camera.main.orthographicSize = distanceBetweenTargets;
            
        }

        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, levelTopLeft.x + cameraClipOffsetX, levelBottomRight.x - cameraClipOffsetX),
           Mathf.Clamp(transform.position.y, levelBottomRight.y + cameraClipOffsetY, levelTopLeft.y - cameraClipOffsetY),
           transform.position.z
       );
        
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,Mathf.Clamp(distanceBetweenTargets, minDistanceZ, maxDistanceZ), Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, 1);
    }
}
