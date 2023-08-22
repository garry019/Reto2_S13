using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovementMixamo playerMovement;

    public float sesitivity = 0;
    private float clampAngle = 30;

    private float verticalRotation;
    private float horizontalRotation;

    private void Awake()
    {
        verticalRotation = transform.localEulerAngles.x;
        horizontalRotation = transform.localEulerAngles.y;
    }

    private void Update()
    {
        Look();
        //Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }

    private void Look()
    {
        float mouseVertical = Input.GetAxis("Mouse Y");
        float mouseHorizontal = -Input.GetAxis("Mouse X");

        verticalRotation += mouseVertical * sesitivity * Time.deltaTime;
        horizontalRotation += mouseHorizontal * sesitivity * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        playerMovement.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }

}
