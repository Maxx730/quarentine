using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int playerSpeed, rotationSpeed;
    public Text isMovingText;
    public Camera camera;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = false;
        bool back = Input.GetKey("s"), forward = Input.GetKey("w"), left = Input.GetKey("a"), right = Input.GetKey("d"), jump = Input.GetKeyDown("space");

        //forward and backward movement
        if (forward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
            isWalking = true;
        }

        if (back)
        {
            transform.Translate(Vector3.back * Time.deltaTime * playerSpeed);
            isWalking = true;
        }

        //Turns player left and right
        if (left)
        {
            transform.Rotate(0, Time.deltaTime * -rotationSpeed, 0);
        }

        if (right)
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
        }

        //Jumping logic here.
        if(jump)
        {

        }

        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler(new Vector4(-1f * (0 * 180f), mouseX * 360f, transform.localRotation.z));
        camera.transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), 0 * 360f, camera.transform.localRotation.z));

        //Update the UI elements here.
        isMovingText.text = "isWalking: " + isWalking.ToString();
    }
}
