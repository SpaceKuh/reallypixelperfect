using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public Transform graphicsTransform;
    public int frameCount = 0;
    public Vector3 realPosition;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        double d = 1 / 16;
        Debug.Log(d);
        this.realPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.frameCount++;
        // if (frameCount % 2 != 0 || frameCount < 2)
        //     return;

        Vector3 move_vector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            move_vector += Vector3.up;
        if (Input.GetKey(KeyCode.A))
            move_vector += Vector3.left;
        if (Input.GetKey(KeyCode.S))
            move_vector += Vector3.down;
        if (Input.GetKey(KeyCode.D))
            move_vector += Vector3.right;

        // move_vector = move_vector.normalized;
        move_vector *= (this.speed * Time.deltaTime);
        this.realPosition += move_vector;
        this.transform.position = PixelPerfectClamp(this.realPosition);

        // this.transform.Translate(4 * (move_vector * ((float)1 / 16)));
        // this.transform.position = PixelPerfectClamp(this.transform.position);
        // graphicsTransform.position = PixelPerfectClamp(this.transform.position);


        // Vector3 old_location = this.transform.position;
        // move_vector = PixelPerfectClamp(move_vector);
        // old_location = PixelPerfectClamp(old_location);

        // this.transform.position = old_location + move_vector;

        // Vector3 moved_distance = old_location - this.transform.position;
        // Debug.Log(moved_distance);
        // move_vector = Vector3.zero;

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
}
