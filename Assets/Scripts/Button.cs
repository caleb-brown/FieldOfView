using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScene
{
    public class Button : MonoBehaviour
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
            Vector3 bVector = new Vector3(pos.x - transform.position.x, 0.0f, pos.z - transform.position.z);
            // Debug.DrawRay(transform.position, bVector, Color.red);
            transform.rotation = Quaternion.LookRotation(bVector + Vector3.right * transform.position.z * Time.deltaTime);
            velocity = new Vector3(bVector.x, 0.0f, bVector.z).normalized * moveSpeed;
            if (bVector.magnitude <= deadZone)
            {
                velocity = Vector3.zero;
            }
        }
    }
}
