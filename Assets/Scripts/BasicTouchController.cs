using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTouchController : MonoBehaviour
{

    public Color defaultColor;
    public Color selectColor;
    public float moveSpeed = 6.0f, deadZone = 1.0f;

    Material mat;
    Camera viewCamera;
    Rigidbody rb;
    Vector3 velocity;
    Vector3 rotation;

    void Awake()
    {
        mat = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
        rotation = new Vector3();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void OnTouchUp()
    {
        Debug.Log("OnTouchUp");
        mat.color = defaultColor;
        velocity = Vector3.zero;
    }

    public void OnTouch(Vector3 pos)
    {
        mat.color = selectColor;
        Vector3 mouseVector = new Vector3(pos.x - transform.position.x, 0.0f, pos.z - transform.position.z);
        Debug.DrawRay(transform.position, transform.position + mouseVector, Color.red);
        transform.rotation = Quaternion.LookRotation((transform.position + mouseVector) + Vector3.right * transform.position.z * Time.deltaTime);
        velocity = new Vector3((mouseVector.x), 0.0f, (mouseVector.z)).normalized * moveSpeed;
        if (mouseVector.magnitude <= deadZone)
        {
            velocity = Vector3.zero;
        }
    }
}
