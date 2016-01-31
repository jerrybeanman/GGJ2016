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

			AnimateMotion ();

			//Add velocity to the object based on this velocity.
			rb2d.MovePosition(rb2d.position + new Vector2(movex, movey) * Speed * Time.fixedDeltaTime);
			Rotate ();
            var audio = GetComponent<AudioSource>();

            if (movex + movey == 0.0f)
            {
                Debug.Log("Pausing");
                if (audio.isPlaying)
                    audio.Pause();
            } else
            {
                Debug.Log("Playing");
                if (!audio.isPlaying)
                    audio.UnPause();
            }
        }	
    }

	void AnimateMotion()
	{
		if (movex == 0 && movey == 0) {
			animator.SetBool ("isMovingForward", false);
			animator.SetBool ("isMovingBack", false);
		} else if (movey > 0) {
			animator.SetBool ("isMovingBack", true);
		}	else
			animator.SetBool ("isMovingForward", true);

	}


    void Update()
    {
        if (target != null && doneLunge == false)
        {
            var freq = 44100;
            var audio = GetComponent<AudioSource>();
            audio.clip = AudioClip.Create("Lunge", freq * 2, 1, freq, true);
            audio.volume = 1;
            audio.PlayOneShot(audio.clip);
            float step = 15 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        }
	}

	void Rotate()
	{
		float target;
		if(movex < 0)
		{ 
			target = Mathf.Atan2(movey, movex);
			transform.localRotation = Quaternion.Euler(0,0, -90);
			VisionTransform.localRotation = Quaternion.Euler(0f, 0f, target * Mathf.Rad2Deg);
		}
		else if (movex > 0)
		{
			target = Mathf.Atan2(movey, -movex);
			transform.localRotation = Quaternion.Euler(180,0,90);
			VisionTransform.localRotation = Quaternion.Euler(0f, 0f, target * Mathf.Rad2Deg);
		}
	}
	
    void DashToEnemy(GameObject target)
    {
        this.target = target;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Human" && target != null && Vector2.Distance(transform.position, other.transform.position) < 20)
        {
            doneLunge = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			doneLunge = false;
			target = null;
			Time.timeScale = 0;
			GameManager.Instance.gameStatus = true;
        }
    }
}

