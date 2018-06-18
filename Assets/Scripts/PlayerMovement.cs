using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f;
    public GameObject[] hearts;


    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public bool canDoubleJump;
    private bool isDoubleJumping = false;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float maxJumpVelocity;
    [SerializeField]
    private float minJumpVelocity;
    public Vector3 velocity;
    private float velocityXSmoothing;

    public Controller2D controller;

    private Vector2 directionalInput;
    private bool wallSliding = false;
    private int wallDirX;

    public Animator animator;

    public float originalSize;
    public BoxCollider2D coll;

    bool ducking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<Controller2D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);


        coll = this.GetComponent<BoxCollider2D>();
        originalSize = coll.size.y;


        StartCoroutine(RefreshCalculations());
        //GameManager.GetInstance().alive = true;
    }

    IEnumerator RefreshCalculations()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
            minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
            gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            transform.position = GameObject.Find("BossRoom").transform.position;
        }

        CalculateVelocity();
        //HandleWallSliding();
        HandleDuck();

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }
    }

    private void HandleDuck()
    {
        //todo: change raycast amount
        float directionVertical = Input.GetAxisRaw("Vertical");

        if (directionVertical < -.5f || Input.GetKey(KeyCode.S))
        {
            animator.Play("crouch");
            ducking = true;
            coll.size = new Vector2(
                coll.size.x,
                originalSize / 2f
            );
            coll.offset = new Vector2(
                0f,
                -1 * originalSize / 4f
            );
        }
        else
        {
            ducking = false;
            coll.size = new Vector2(
                coll.size.x,
                originalSize
            );
            coll.offset = new Vector2(
                0f,
                0f
            );
        }

        controller.CalculateRaySpacing();
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            //if (wallDirX == directionalInput.x)
            //{
            //    velocity.x = -wallDirX * wallJumpClimb.x;
            //    velocity.y = wallJumpClimb.y;
            //}
            //else if (directionalInput.x == 0)
            //{
            //    velocity.x = -wallDirX * wallJumpOff.x;
            //    velocity.y = wallJumpOff.y;
            //}
            //else
            //{
            //    velocity.x = -wallDirX * wallLeap.x;
            //    velocity.y = wallLeap.y;
            //}
            //isDoubleJumping = false;
        }
        if (controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = false;
        }
        if (canDoubleJump && !controller.collisions.below && !isDoubleJumping && !wallSliding)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = true;
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    private void HandleWallSliding()
    {
        //wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        //if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        //{
        //    wallSliding = true;

        //    if (velocity.y < -wallSlideSpeedMax)
        //    {
        //        velocity.y = -wallSlideSpeedMax;
        //    }

        //    if (timeToWallUnstick > 0f)
        //    {
        //        velocityXSmoothing = 0f;
        //        velocity.x = 0f;
        //        if (directionalInput.x != wallDirX && directionalInput.x != 0f)
        //        {
        //            timeToWallUnstick -= Time.deltaTime;

        //        }
        //        else
        //        {
        //            timeToWallUnstick = wallStickTime;
        //        }
        //    }
        //    else
        //    {
        //        timeToWallUnstick = wallStickTime;
        //    }
        //}
    }

    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;
    }

  
}
