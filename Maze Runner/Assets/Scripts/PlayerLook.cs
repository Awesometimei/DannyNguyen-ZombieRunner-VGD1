using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float verticalMax = 60f;
    public float verticalMin = -45f;
    public float mouseX, mouseY;

    public Transform target, player, obstruction;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void CursorMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        if(gameManager.isGameActive == true)
        {
            CursorMode();
            AnchorCamera();
            CamControl();
        }
    }

    void AnchorCamera()
    {
        transform.position = target.transform.position;
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, verticalMin, verticalMax);

        transform.LookAt(target);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
