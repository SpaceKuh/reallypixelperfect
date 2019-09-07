using UnityEngine;
using System;
public class PixelPos : MonoBehaviour
{
    [SerializeField]
    private float pixelsPerUnit = 16;
    [SerializeField]
    private float unitsPerPixel;
    [SerializeField]
    private Transform m_transform;

    private void Awake()
    {
        this.m_transform = this.transform;
        this.unitsPerPixel = 1 / this.pixelsPerUnit;
        Debug.Log(pixelsPerUnit);
        Debug.Log(unitsPerPixel);
    }

    private void LateUpdate()
    {
        Vector3 fixed_position;

        fixed_position.x = Mathf.Round(this.m_transform.position.x / unitsPerPixel) * unitsPerPixel;
        fixed_position.y = Mathf.Round(this.m_transform.position.y / unitsPerPixel) * unitsPerPixel;
        fixed_position.z = m_transform.position.z;

        this.transform.position = fixed_position;
    }
}