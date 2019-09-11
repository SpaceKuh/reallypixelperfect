using UnityEngine;

public class DespairPlayer : MonoBehaviour
{
    private Transform m_transform;
    public float speed;
    public Transform graphic;
    public bool isMoving = false;

    private void Awake()
    {
        this.m_transform = this.transform;
    }

    private void Update()
    {
        Vector3 move_vector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move_vector += Vector3.up;
        if (Input.GetKey(KeyCode.A))
            move_vector += Vector3.left;
        if (Input.GetKey(KeyCode.S))
            move_vector += Vector3.down;
        if (Input.GetKey(KeyCode.D))
            move_vector += Vector3.right;

        if (move_vector != Vector3.zero)
            this.m_transform.Translate(move_vector * (speed * Time.deltaTime));

        else
        {
            graphic.position = PixelPerfectClamp(this.m_transform.position);
            this.m_transform.position = graphic.position;
        }
        // graphic.position = PixelPerfectClamp(this.m_transform.position);




    }

    private Vector3 PixelPerfectClamp(Vector3 move_vector)
    {
        Vector3 vector_in_pixels = new Vector3
        (
            Mathf.RoundToInt(move_vector.x * 16),
            Mathf.RoundToInt(move_vector.y * 16),
            0
        );

        return vector_in_pixels / 16;
    }

    private Vector3 PixelPerfectClampMovement(Vector3 move_vector, Vector3 direction)
    {
        int x;
        int y;

        if (move_vector.x < 0)
            x = Mathf.CeilToInt(move_vector.x * 16);
        else
            x = Mathf.FloorToInt(move_vector.x * 16);

        if (move_vector.y < 0)
            y = Mathf.CeilToInt(move_vector.y * 16);
        else
            y = Mathf.FloorToInt(move_vector.y * 16);

        Vector3 vector_in_pixels = new Vector3
            (
                x, y,
                0
            );

        return vector_in_pixels / 16;
    }
}