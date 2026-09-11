using UnityEngine;

public class SearchAngle : MonoBehaviour
{
    [Range(0f, 360f)]
    public float detectionAngle = 90f;

    public float debugDistance = 5f;
    public Color angleColor = Color.green;

    [Header("Dot Product Debug")]
    [SerializeField] private float leftEdgeDotProduct;
    [SerializeField] private float rightEdgeDotProduct;

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;

        Vector3 forward = transform.forward;
        forward.y = 0f;

        if (forward.sqrMagnitude <= Mathf.Epsilon)
            forward = Vector3.forward;
        else
            forward.Normalize();

        float halfAngle = detectionAngle * 0.5f;

        Vector3 leftDirection =
            Quaternion.AngleAxis(-halfAngle, Vector3.up) * forward;

        Vector3 rightDirection =
            Quaternion.AngleAxis(halfAngle, Vector3.up) * forward;

        leftEdgeDotProduct = Vector3.Dot(forward, leftDirection);
        rightEdgeDotProduct = Vector3.Dot(forward, rightDirection);

        Debug.DrawRay(
            origin,
            forward * debugDistance,
            Color.blue
        );

        Debug.DrawRay(
            origin,
            leftDirection * debugDistance,
            angleColor
        );

        Debug.DrawRay(
            origin,
            rightDirection * debugDistance,
            angleColor
        );

        Gizmos.color = angleColor;

        const int segments = 32;

        Vector3 previousPoint =
            origin + leftDirection * debugDistance;

        for (int i = 1; i <= segments; i++)
        {
            float currentAngle =
                Mathf.Lerp(
                    -halfAngle,
                    halfAngle,
                    i / (float)segments
                );

            Vector3 direction =
                Quaternion.AngleAxis(
                    currentAngle,
                    Vector3.up
                ) * forward;

            Vector3 currentPoint =
                origin + direction * debugDistance;

            Gizmos.DrawLine(previousPoint, currentPoint);

            previousPoint = currentPoint;
        }

        Gizmos.DrawLine(
            origin,
            origin + leftDirection * debugDistance
        );

        Gizmos.DrawLine(
            origin,
            origin + rightDirection * debugDistance
        );
    }
}