using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float rotateSpeed = 20.0f, speed = 10.0f, zoomSpeed = 1000.0f;

    private float _mult = 1f;

    private void Update()
    {
        //Передвижение камеры
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Поворот камеры
        float rotate = 0f;
        if(Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if(Input.GetKey(KeyCode.E))
            rotate = 1f;

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        //Формулы передвижения и поворота
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        transform.position += transform.up * zoomSpeed * Time.deltaTime * _mult * Input.GetAxis("Mouse ScrollWheel");


        //ограничение карты
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -150f, 150f),
            Mathf.Clamp(transform.position.y, -10f, 30f),
            Mathf.Clamp(transform.position.z, -150f, 150f)
            );
    }
}
