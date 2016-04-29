using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public void moveLeft(float speed, Rigidbody2D moveable)                     //The ship's AI script passes in a speed to a method
    {                                                                           //The method creates a directional vector
        Vector3 checkLeft = new Vector3(-1, 0, 0);                              //The method then casts a ray to see if there is anything there
        if (!Physics2D.Raycast(transform.position, checkLeft, 1))               //The enemy is then moved into that position if there is nothing there
        {
            moveable.velocity = new Vector3(-1, 0, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkLeft, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
        }
    }
    public void moveRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkRight = new Vector3(1, 0, 0);
        if (!Physics2D.Raycast(transform.position, checkRight, 1))
        {
            moveable.velocity = new Vector3(speed, 0, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkRight, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
        }
    }
    public void moveUp(float speed, Rigidbody2D moveable)
    {
        Vector3 checkUp = new Vector3(0, 1, 0);
        if (!Physics2D.Raycast(transform.position, checkUp, 1))
        {
            moveable.velocity = new Vector3(0, speed, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkUp, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
        }
    }
    public void moveDown(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDown = new Vector3(0, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDown, 1))
        {
            moveable.velocity = new Vector3(0, speed*-1, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkDown, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
        }
    }
    public void moveDownLeft(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDownLeft = new Vector3(-1, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDownLeft, 1))
        {
            moveable.velocity = new Vector3(speed*-1, speed * -1, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkDownLeft, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
            moveLeft(speed, moveable);
            moveDown(speed, moveable);
        }
    }
    public void moveDownRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDownRight = new Vector3(1, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDownRight, 1))
        {
            moveable.velocity = new Vector3(speed, speed * -1, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkDownRight, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
            moveDown(speed, moveable);
            moveRight(speed, moveable);
        }
    }
    public void moveUpLeft(float speed, Rigidbody2D moveable)
    {
        Vector3 checkUpLeft = new Vector3(-1, 1, 0);
        if (!Physics2D.Raycast(transform.position, checkUpLeft, 1))
        {
            moveable.velocity = new Vector3(speed*-1, speed , 0);
        }
        else if (Physics2D.Raycast(transform.position, checkUpLeft, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
            moveLeft(speed, moveable);
            moveUp(speed, moveable);
        }
    }
    public void moveUpRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkUpRight = new Vector3(1, 1, 0);
        if (!Physics2D.Raycast(transform.position, checkUpRight, 1))
        {
            moveable.velocity = new Vector3(speed, speed, 0);
        }
        else if (Physics2D.Raycast(transform.position, checkUpRight, 1))
        {
            moveable.velocity = new Vector3(0, 0, 0);
            moveRight(speed, moveable);
            moveUp(speed, moveable);
        }
    }
    public void stopMoving(Rigidbody2D moveable)
    {
        moveable.velocity = new Vector3(0, 0, 0);
    }
}