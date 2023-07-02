using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlTest : MonoBehaviour
{
    [SerializeField] private float camSpeed;
    private int camDirection;
    private int leftDirection;
    private int rightDirection;
    private Transform cameraTransform;
    private Vector3 camPos;

    private void Start()
    {
        Application.targetFrameRate = 300;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        cameraTransform = transform;
        camPos = cameraTransform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopMoveRight();
        }
    }

    private void FixedUpdate()
    {
        camDirection = leftDirection + rightDirection;
        camPos.x = cameraTransform.position.x + camDirection;
        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, camPos, Time.fixedDeltaTime * camSpeed);
    }


    public void MoveLeft()
    {
        leftDirection = -1;
    }

    public void StopMoveLeft()
    {
        leftDirection = 0;
    }

    public void MoveRight()
    {
        rightDirection = 1;
    }

    public void StopMoveRight()
    {
        rightDirection = 0;
    }
}
