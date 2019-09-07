using UnityEngine.UI;
using UnityEngine;
using System;
[RequireComponent(typeof(InputField))]
public class SetMovementSpeed : MonoBehaviour
{
    private InputField inputField;
    [SerializeField]
    private Player player;
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
            this.player.speed = newSpeed;
        }
        catch (System.Exception)
        {

        }
    }

}
