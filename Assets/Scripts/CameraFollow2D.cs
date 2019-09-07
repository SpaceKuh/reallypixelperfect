using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    private Vector3 realPosition;

    private void Awake()
    {
        this.realPosition = this.transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        this.realPosition = Vector3.Slerp(this.realPosition, newPosition, FollowSpeed * Time.deltaTime);
        this.transform.position = PixelPerfectClamp(this.realPosition);
    }

    private Vector3 PixelPerfectClamp(Vector3 move_vector)
    {
        Vector3 vector_in_pixels = new Vector3
        (
            Mathf.RoundToInt(move_vector.x * 16),
            Mathf.RoundToInt(move_vector.y * 16),
            -10
        );

        return vector_in_pixels / 16;
    }
}