using UnityEngine;
using System.Collections;

/*
Carson:
Basic WASD absolute/static movement.
*/
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    //Speed to move at
    public float Speed = 0;

    //Horizontal movement. 1 is right, -1 is left, 0 is no movement.
    private float movex;

    //Vertical movement. 1 is up, -1 is down, 0 is no movement.
    private float movey;

    private GameObject target = null;
    private bool doneLunge = false;
    
	private Animator 	animator;
	private Rigidbody2D rb2d;
	private Transform 	VisionTransform;
    //Start of scripts creation. Used to instantiate variables in our case.
    void Start() 
	{
        movex = 0f;
        movey = 0f;
		VisionTransform = this.gameObject.transform.GetChild(1);
		animator = GetComponentInChildren<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
    }
    
    //Called every frame
    void FixedUpdate() {
		if (target == null && doneLunge == false)
        {
        //Get the x and y movement
			movex = Input.GetAxis("Horizontal");
			movey = Input.GetAxis("Vertical");
        	if(movex == 0 && movey == 0)
				animator.SetBool("isMoving", false);
			else
				animator.SetBool("isMoving", true);
			//Add velocity to the object based on this velocity.
			rb2d.MovePosition(rb2d.position + new Vector2(movex, movey) * Speed * Time.fixedDeltaTime);
			if(movex < 0)
			{
				transform.localRotation = Quaternion.Euler(0,0, -90);
			}else if (movex > 0)
				transform.localRotation = Quaternion.Euler(180,0,90);
		}	
    }

    void Update()
    {
        if (target != null && doneLunge == false)
        {
            float step = 20 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }else if(movex > 0)
		{
			transform.localRotation = Quaternion.Euler(180,0,90);
	
		}
	}
    void DashToEnemy(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
		rb2d.AddForce(direction * 10000);
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

