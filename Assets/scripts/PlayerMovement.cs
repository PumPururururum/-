using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D contactFilter;
    public Rigidbody2D RigBody;
    public VariableJoystick joystick;

    public  Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    //float HorizontalInput, VerticalInput;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y) && movement.x > 0) { animator.SetInteger("LastMove", 2); }
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y) && movement.x < 0) { animator.SetInteger("LastMove", 1); }
        if (Mathf.Abs(movement.x) < Mathf.Abs(movement.y) && movement.y > 0) { animator.SetInteger("LastMove", 4); }
        if (Mathf.Abs(movement.x) < Mathf.Abs(movement.y) && movement.y < 0) { animator.SetInteger("LastMove", 3); }
    }
    private void FixedUpdate()
    {
        movement = joystick.Direction;
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }
        if (movement != Vector2.zero ) 
        {
            bool success = TryMove(movement);
            if (!success)
            {
                success = TryMove(new Vector2(movement.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, movement.y));
                }
            }
        }
         
    }

    private bool TryMove(Vector2 direction)
    {
        int count = RigBody.Cast(
            direction,
            contactFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            RigBody.MovePosition(RigBody.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else { return false; }
    }
}
