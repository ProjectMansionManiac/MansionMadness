using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public int health;
    public GameObject[] hearts;

    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    private float moveSpeed = 6f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public bool canDoubleJump;
    private bool isDoubleJumping = false;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
    private Vector3 velocity;
    private float velocityXSmoothing;

    private Controller2D controller;

    private Vector2 directionalInput;
    private bool wallSliding = false;
    private int wallDirX;

    public Animator animator;

    public float originalSize;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        RefreshHealthbar();

        originalSize = this.transform.localScale.y;

        GameManager.GetInstance().currentState.currentCheckPoint = transform.position;
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        RefreshHealthbar();
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Text winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.enabled = true;
        winText.text = "GAME OVER";

        Time.timeScale = 0f;


        Destroy(this.gameObject);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
    }

    void RefreshHealthbar()
    {
        //if (health == 0)
        //{
        //    hearts[0].SetActive(false);
        //    hearts[1].SetActive(false);
        //    hearts[2].SetActive(false);
        //}
        //else if (health == 1)
        //{
        //    hearts[0].SetActive(true);
        //    hearts[1].SetActive(false);
        //    hearts[2].SetActive(false);
        //}
        //else if (health == 2)
        //{
        //    hearts[0].SetActive(true);
        //    hearts[1].SetActive(true);
        //    hearts[2].SetActive(false);
        //}
        //else if (health >= 3)
        //{
        //    hearts[0].SetActive(true);
        //    hearts[1].SetActive(true);
        //    hearts[2].SetActive(true);
        //}
    }
}
