using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTouchController : MonoBehaviour 
{
    public float moveSpeed = 6.0f, timeScale = 1.0f;

    int counter;
    Rigidbody rb;
    Camera mainCamera;
    Vector3 velocity, rotation, previousPos;
    List<Vector3> posList = new List<Vector3>();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        velocity = new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate () 
	{
        if (counter < posList.Count)
        {
            transform.position = Vector3.Lerp(posList[counter - 1], posList[counter], moveSpeed * Time.deltaTime);
            Debug.Log(string.Format("{0}", Time.time));
            if (transform.position == posList[counter])
            {
                counter++;
            }
        }

        // rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    public void OnTouchUp(List<Vector3> lineList)
    {
        counter = 1;
        posList = lineList;

        // previousPos = posList[0];
        /*Debug.Log("OnTouchUp");

        // Vector3 previousPos = lineList[0];
        for (int i = 0; i < lineList.Count; i++)
        {
            velocity = lineList[i].normalized * moveSpeed;
            // rb.MovePosition(rb.position + velocity * Time.deltaTime);
            Debug.Log(velocity);
        }*/


    }

    public void OnTouchDown()
    {

    }
}
