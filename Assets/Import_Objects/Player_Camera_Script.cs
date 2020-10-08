using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Script : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    [SerializeField]
    private float maxValue = 100;
    [SerializeField]
    private float minValue = -100;
    [SerializeField]
    private float speedH = 1f;
    [SerializeField]
    private float speedW = 1f;

    // Update is called once per frame
    void Update()
    {
        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY -= speedW * Input.GetAxis("Mouse Y");
        //camRotation.x += Input.GetAxis("Mouse Y")*(-1);
        //camRotation.y += Input.GetAxis("Mouse X");

        mouseY = Mathf.Clamp(mouseY, minValue, maxValue);

        //transform.eulerAngles = new Vector3(camRotation.x, camRotation.y, camRotation.z);
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
