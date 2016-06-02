using UnityEngine;
using System.Collections;

#if UNITY_ANDROID || UNITY_IOS
    
using UnityStandardAssets.CrossPlatformInput;
    
#endif


public class Controller : MonoBehaviour
{
	public float moveSpeed = 6;

    Camera viewCamera;
	
    Rigidbody rigidBody;
	Vector3 velocity;
    
    // Use this for initialization
    void Start ()
    {	
        rigidBody = GetComponent<Rigidbody> ();
        viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL
        
        if (Input.GetKey("escape"))
            Application.Quit();

		Vector3 mPos = viewCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		transform.LookAt(mPos + Vector3.up * transform.position.y);
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
        
#endif

#if UNITY_ANDROID || UNITY_IOS

        Vector3 mPos = viewCamera.ScreenToWorldPoint(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), viewCamera.transform.position.y));
        // Vector3 mPos = viewCamera.ScreenToWorldPoint(new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse_X"), CrossPlatformInputManager.GetAxisRaw("Mouse_Y"), viewCamera.transform.position.y));
        transform.LookAt(mPos + Vector3.up * transform.position.y);
        velocity = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical")).normalized * moveSpeed;

#endif

    }

	void FixedUpdate()
	{
		rigidBody.MovePosition (rigidBody.position + velocity * Time.fixedDeltaTime);
    }
}
