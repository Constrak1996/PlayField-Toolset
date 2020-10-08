using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    private float speed = 100;
    private float mouseX;
    private float mouseY;
    private Transform player_Camera;
    public string type;
    [SerializeField]
    private float speedH = 2f;
    [SerializeField]
    private float speedW = 2f;
    // Start is called before the first frame update
    private void Awake()
    {
        type = this.gameObject.name;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.25f * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.25f * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.25f * Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.25f * Time.deltaTime * speed, 0, 0);
        }

        player_Camera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Transform>();
        mouseX += speedH * Input.GetAxis("Mouse X");
        //mouseY -= speedW * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0, player_Camera.eulerAngles.y, 0);
    }
    private void OnDestroy()
    {

    }
}
