using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 1000f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime; // paņem ievadi no peles X kustības
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime; // -//- no Y kustības

        xRotation -= mouseY; // skaitlis, kas norāda, cik tālu ir rotēts AP x asi (ja ieliek plusu, būs invertedf)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ierobežo rotāciju pa 180 grādiem

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // rotē pa y asi (up, down)
        playerBody.Rotate(Vector3.up * mouseX); // rotē pa x asi (left, right)
    }
}
