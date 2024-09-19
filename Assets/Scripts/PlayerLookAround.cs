using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float mouseSensivity;
    private float xRotation, yRotation;
    private float limitedYRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        yRotation = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRotation = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;

        limitedYRotation -= yRotation;
        limitedYRotation = Mathf.Clamp(limitedYRotation, -90f, 90f);
        
        
        transform.localRotation = Quaternion.Euler(limitedYRotation, 0f, 0f);
        player.transform.Rotate(Vector3.up * xRotation);
    }
}
