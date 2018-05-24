using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (!Input.GetButton("Jump"))
        {
            if (directionalInput == Vector2.zero)
            {
                player.animator.Play("Idle");
            }
            else if (-.2f > directionalInput.x && directionalInput.x > .2f )
            {
                player.animator.Play("Walk");
            }
        }

        if (directionalInput == Vector2.left)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        playerMovement.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.OnJumpInputDown();
            player.animator.Play("Jump");
        }

        if (Input.GetButtonUp("Jump"))
        {
            playerMovement.OnJumpInputUp();
            player.animator.Play("Idle");
        }
    }
}
