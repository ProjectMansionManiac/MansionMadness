using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (directionalInput == Vector2.zero)
        {
            player.animator.Play("Idle");
        } else
        {
            player.animator.Play("Walk");
        }

        if (directionalInput == Vector2.left)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
            player.animator.Play("Jump");
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
            player.animator.Play("Idle");
        }
    }
}
