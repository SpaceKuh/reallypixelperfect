using UnityEngine;

public class SetFollowCamera : MonoBehaviour
{
    public CameraFollow2D cam;
    public void ToggleFollow()
    {
        this.cam.SetFollow(!cam.follow);
    }
}
