using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerController : MonoBehaviour

{



    [System.Serializable]

    public class MoveSettings

    {

        public float forwardVel = 12;

        public float rotateVel = 100;

        public float distToGrounded = 0.1f;

        public LayerMask ground;

    }



    [System.Serializable]

    public class PhysSettings

    {

        public float downAccel = 0.75f;

    }



    [System.Serializable]

    public class InputSettings

    {

        public float inputDelay = 0.1f;



    }



    public MoveSettings moveSettings = new MoveSettings();

    public PhysSettings physSettings = new PhysSettings();

    public InputSettings inputSettings = new InputSettings();



    Vector3 velocity = Vector3.zero;

    float gravityVel = 0;

    Quaternion targetRotation;

    Rigidbody rBody;

    float forwardInput, turnInput;

    float camRayLength = 100f;



    public Quaternion TargetRotation

    {

        get { return targetRotation; }

    }



    bool Grounded()

    {



#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view

        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * moveSettings.distToGrounded));

#endif
        return Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, moveSettings.distToGrounded, moveSettings.ground);





    }



    void Start()

    {

        targetRotation = transform.rotation;

        if (GetComponent<Rigidbody>())

            rBody = GetComponent<Rigidbody>();

        else

            Debug.LogError("Char needs rigidbody");



        forwardInput = turnInput = 0;



    }



    void GetInput()

    {

        forwardInput = Input.GetAxis("Vertical");

        turnInput = Input.GetAxis("Horizontal");

    }



    void Update()

    {

        GetInput();
        FollowMouse();



    }



    void FixedUpdate()

    {

        Run();

        //Airborne();

        //rBody.velocity = transform.TransformDirection(velocity);

        rBody.MovePosition(transform.position + velocity);





    }



    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else
        {
            velocity.z = 0;
        }
        if (Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            velocity.x = moveSettings.forwardVel * turnInput;
        }
        else
        {
            velocity.x = 0;
        }
    }

    void FollowMouse()
    {   
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, moveSettings.ground))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;
            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;
            
            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            
            // Set the player's rotation to this new rotation.
            rBody.MoveRotation(newRotation);

        }
    }
}
