using UnityEngine;

public class PixelMovement : MonoBehaviour
{
    public Transform m_transform;
    public float speed = 1;

    private float pixelSize;
    [SerializeField]

    private float targetFrameInterval;

    private float pixelBuffer = 0;
    private float timeBuffer = 0;

    private float timeSinceLastMove = 0;

    private void Awake()
    {
        if (this.m_transform == null)
            this.m_transform = this.transform;

        this.targetFrameInterval = (float)1 / 60;
        this.pixelSize = (float)1 / 16;
        Debug.Log("One pixel in units: " + this.pixelSize);
    }


    private void Update()
    {
        this.timeBuffer += Time.deltaTime;
        if (timeBuffer >= targetFrameInterval)
        {
            this.timeBuffer = 0;
            this.pixelBuffer += speed;
        }

        if (this.pixelBuffer >= 1)
        {
            float time_since_last_move = Time.time - this.timeSinceLastMove;
            Debug.Log("moved after: " + time_since_last_move + "ms");
            int pixels_to_move = Mathf.FloorToInt(this.pixelBuffer);
            this.m_transform.Translate((pixels_to_move * this.pixelSize) * Vector3.right);
            this.timeSinceLastMove = Time.time;
            this.pixelBuffer -= pixels_to_move;
            if (this.pixelBuffer < 0)
                this.pixelBuffer = 0;
        }
    }




}