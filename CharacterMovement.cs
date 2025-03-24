using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f; // Rotation speed in degrees per second
    public Animator animator;
    public CharacterController controller; // Use CharacterController
    //public Rigidbody rigidbody; //Use rigidbody instead of character controller.

    void Start()
    {
        controller = GetComponent<CharacterController>(); //get Character Controller
        //rigidbody = GetComponent<Rigidbody>(); //get rigidbody
        animator = GetComponent<Animator>();

        //print(Random.Range(0, 100));
    }

    
    void Update()
    {

        ////
        /////
        /////
        ///
        /////




        //print(Input.GetKeyDown(KeyCode.O));

        //bool isWalking = animator.GetBool("isWalking");



        if (animator.GetBool("isWalking") && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {

            animator.SetBool("isWalking", false);
            print("why not");



            //animator.Play("walk");

        }



        else if (!animator.GetBool("isWalking") && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
           
                animator.SetBool("isWalking", true);
           
            
            //animator.Play("walk");
            
        }

        
        //|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))


        
        




        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = -1* new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f )
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetAngle, 0), rotationSpeed * Time.deltaTime);

            Vector3 moveVelocity = moveDirection * moveSpeed;
            moveVelocity.y -= 9.81f;
            controller.Move(moveVelocity * Time.deltaTime); //move character controller
                                                            //rigidbody.velocity = moveVelocity; //move rigidbody


        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        
    }
}