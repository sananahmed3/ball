using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f; // Rotation speed in degrees per second
    public Animator animator;
    public CharacterController controller; // Use CharacterController
    
    public float jumpHeight;
   

    public Vector3 moveVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>(); //get Character Controller
        
        animator = GetComponent<Animator>();

    }


    void Update()
    {

        



        if (animator.GetBool("isWalking") && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {

            animator.SetBool("isWalking", false);



        }



        else if (!animator.GetBool("isWalking") && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {

            animator.SetBool("isWalking", true);



            
        }


        



        


            float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = -1 * new Vector3(horizontal, 0, vertical).normalized;




        moveVelocity.y -= 9.81f;


        if (animator.GetBool("isJumping"))
        {

            moveDirection += new Vector3(0, jumpHeight, 0);
            controller.Move(moveVelocity * Time.deltaTime);
        }



        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetAngle, 0), rotationSpeed * Time.deltaTime);


            moveVelocity = moveDirection * moveSpeed;
            moveVelocity.y -= 9.81f;



            //when walking he jumps he stays up





            //controller.Move(moveVelocity * Time.deltaTime);
            


        }
        else
        {
            animator.SetBool("isIdle", true);


            moveVelocity.x = 0;
            moveVelocity.z = 0;
            
            
        }
        controller.Move(moveVelocity * Time.deltaTime);
        Jump();




    }


    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (!animator.GetBool("isJumping"))
            {
                animator.SetBool("isJumping", true);


                Transform transform = GetComponent<Transform>();
                //rigidbody.AddForce(Vector3.up);

                //controller.Move(new Vector3(moveDirection.x, jumpHeight, moveDirection.z));
            }
        }
        else if (!Input.GetKey(KeyCode.Space))
        {

            animator.SetBool("isJumping", false);
        }
    }

}