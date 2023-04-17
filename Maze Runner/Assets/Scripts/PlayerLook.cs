using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float verticalMax = 60f;
    public float verticalMin = -45f;
    public Transform target, player, obstruction;

    public float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        AnchorCamera();
        CamControl();
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
