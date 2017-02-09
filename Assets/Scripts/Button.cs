using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScene
{
    public class Button : MonoBehaviour
    {

        public Color defaultColor;
        public Color selectColor;
        public float moveSpeed = 6.0f;

        Material mat;
        Camera viewCamera;
        Rigidbody rb;
        Vector3 velocity;

        void Awake()
        {
            mat = GetComponent<Renderer>().material;
            rb = GetComponent<Rigidbody>();
            viewCamera = Camera.main;
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

            Vector3 mPos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            transform.LookAt(mPos + Vector3.up * transform.position.y * Time.deltaTime);
            velocity = new Vector3(pos.x, pos.y, 0.0f).normalized * moveSpeed;
            Debug.DrawRay(transform.position, velocity);
        }

        void OnTouchExit()
        {
            mat.color = defaultColor;
        }
    }
}
