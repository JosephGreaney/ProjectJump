using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public void moveLeft(float speed, Rigidbody2D moveable)
    {
        Vector3 checkLeft = new Vector3(-1, 0, 0);
        if (Physics2D.Raycast(transform.position, checkLeft, 1))
        {
            //print("There is something there left");
            moveable.velocity = new Vector3(speed * -1, 0, 0);
        }
        else if (!Physics2D.Raycast(transform.position, checkLeft, 1))
        {
            //print("There is nothing there");
        }
    }
    public void moveRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkRight = new Vector3(1, 0, 0);
        if (Physics2D.Raycast(transform.position, checkRight, 1))
        {
            //print("There is something right");
            moveable.velocity = new Vector3(speed, 0, 0);
        }
    }
    public void moveUp(float speed, Rigidbody2D moveable)
    {
        Vector3 checkUp = new Vector3(0, 1, 0);
        if (!Physics2D.Raycast(transform.position, checkUp, 2))
        {
            moveable.velocity = new Vector3(0, speed, 0);
        }
    }
    public void moveDown(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDown = new Vector3(0, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDown, 2))
        {
            moveable.velocity = new Vector3(0, speed*-1, 0);
        }
    }
    public void moveDownLeft(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDown = new Vector3(0, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDown, 2))
        {
            moveable.velocity = new Vector3(speed*-1, speed * -1, 0);
        }
    }
    public void moveDownRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDown = new Vector3(0, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDown, 2))
        {
            moveable.velocity = new Vector3(speed, speed * -1, 0);
        }
    }
    public void moveUpLeft(float speed, Rigidbody2D moveable)
    {
        Vector3 checkUpLeft = new Vector3(-1, 1, 0);
        RaycastHit hit;
        if (!Physics2D.Raycast(transform.position, checkUpLeft, 1f))
        {
            print("there's not something there");
            moveable.velocity = new Vector3(speed*-1, speed , 0);
        }
        else if (Physics.Raycast(transform.position, checkUpLeft,out hit, 1f))
        {
            print("nameless");
            print(hit.collider.gameObject.name);
        }
    }
    public void moveUpRight(float speed, Rigidbody2D moveable)
    {
        Vector3 checkDown = new Vector3(0, -1, 0);
        if (!Physics2D.Raycast(transform.position, checkDown, 2))
        {
            moveable.velocity = new Vector3(speed, speed, 0);
        }
    }
}