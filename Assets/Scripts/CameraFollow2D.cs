using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 21f;
    public Transform Target;
    private Vector3 realPosition;
    private DespairPlayer player;
    [SerializeField]
    private float distanceThreshold;

    public Transform graphic;
    public bool follow = true;

    private void Awake()
    {
        this.realPosition = this.transform.position;
        this.distanceThreshold = 10;
        float unitPerPixel = (float)1 / 16;
        Debug.Log(unitPerPixel);
        this.distanceThreshold += unitPerPixel;
    }

    private void Start()
    {
        this.player = this.Target.GetComponent<DespairPlayer>();
        this.graphic = this.player.graphic;
    }

    private void LateUpdate()
    {
        if (!this.follow)
            return;
        Vector3 newPosition = Target.position;
        Vector3 distance = newPosition - this.transform.position;
        Debug.Log("distance: " + distance.magnitude);
        // if (distance.magnitude < this.distanceThreshold)
        // {
        //     this.transform.position = PixelPerfectClamp(this.Target.position);
        //     return;
        // }
        newPosition.z = -10;
        this.realPosition = Vector3.Slerp(this.realPosition, newPosition, FollowSpeed * Time.deltaTime);
        this.realPosition.z = -10;
        // this.transform.position = new Vector3(Mathf.RoundToInt(this.realPosition.x), Mathf.RoundToInt(this.realPosition.y), -10);
        this.transform.position = this.realPosition;
        // this.transform.position = PixelPerfectClamp(this.realPosition);
    }

    private Vector3 PixelPerfectClamp(Vector3 move_vector)
    {
        Vector3 vector_in_pixels = new Vector3
        (
            Mathf.RoundToInt(move_vector.x * 16),
            Mathf.RoundToInt(move_vector.y * 16),
            -10
        );

        vector_in_pixels /= 16;
        vector_in_pixels.z = -10;
        return vector_in_pixels;
    }

    public void SetFollow(bool value)
    {
        if (this.follow != value)
        {
            this.follow = value;
            if (value == true)
            {
                this.transform.parent = null;
                this.transform.position = this.graphic.position;
            }
            else
            {
                this.transform.parent = this.graphic;
                this.transform.localPosition = new Vector3(0, 0, -10);
            }
        }
    }
}