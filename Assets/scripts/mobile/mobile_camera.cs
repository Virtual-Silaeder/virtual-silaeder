using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile_camera : MonoBehaviour
{
    public Transform camera;
    Vector3 firstPoint;
    Vector3 secondPoint;
    public float xAngle;
    public float yAngle;
    float xAngleTemp;
    float yAngleTemp;
    private void Start()
    {
        yAngle = transform.localRotation.eulerAngles.y;
    }
    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("touched");
            if (touch.position.x>Screen.width/2 & touch.phase==TouchPhase.Began)
            {
                firstPoint = touch.position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (touch.position.x > Screen.width / 2 & touch.phase == TouchPhase.Moved)
            {
                secondPoint = touch.position;
                xAngle = xAngleTemp-(secondPoint.y - firstPoint.y) * 90 /Screen.height;
                yAngle = yAngleTemp - (secondPoint.x - firstPoint.x) * 180 / Screen.width;  
                transform.rotation = Quaternion.Euler(0, yAngle, 0);
                xAngle = Mathf.Clamp(xAngle, -80, 80);
                camera.rotation = Quaternion.Euler(xAngle, yAngle, 0);
            }
        }
    }
}
