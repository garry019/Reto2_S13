using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovementMixamo playerMovement;

    private float sesitivity = -100;
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
