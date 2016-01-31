using UnityEngine;
using System.Collections;

/*
Carson:
Basic WASD absolute/static movement.
*/
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //Speed to move at
    public float Speed = 0;

    //Horizontal movement. 1 is right, -1 is left, 0 is no movement.
    private float movex;

    //Vertical movement. 1 is up, -1 is down, 0 is no movement.
    private float movey;

    private GameObject target = null;
    private bool doneLunge = false;

    //Start of scripts creation. Used to instantiate variables in our case.
    void Start()
    {
        movex = 0f;
        movey = 0f;
    }

    //Called every frame
    void FixedUpdate()
    {
        if (target == null && doneLunge == false)
        {
            //Get the x and y movement
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
            //Add velocity to the object based on this velocity.
            GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
        }
    }

    void Update()
    {
        if (target != null && doneLunge == false)
        {
            float step = 20 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    void DashToEnemy(GameObject target)
    {
        this.target = target;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human" && target != null && Vector2.Distance(transform.position, other.transform.position) < 2)
        {
            doneLunge = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(other.gameObject);
        }
    }
}
