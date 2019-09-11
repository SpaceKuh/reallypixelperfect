using UnityEngine;
using UnityEngine.UI;
using System;

public class SetCameraSpeed : MonoBehaviour
{

    private InputField inputField;
    [SerializeField]
    private CameraFollow2D cam;
    private void Awake()
    {
        this.inputField = this.gameObject.GetComponent<InputField>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSpeed()
    {
        try
        {
            int newSpeed = Convert.ToInt32(inputField.text);
            this.cam.FollowSpeed = newSpeed;
        }
        catch (System.Exception)
        {

        }
    }
}
