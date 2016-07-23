using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BridScripts : MonoBehaviour {
    public float moveForce;
    //tốc độ nhảy của brid.
    public float bounceForce;
    private Rigidbody2D myBody;
    private Animator anim;
    //bấm vào button brid nhảy 1 lần.
    private bool didFlap;
    //nếu mà brid IsAlive thì sẽ có thể di chuyen  và nhảy
    private bool bridIsAlive;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapClip, pingClip, dieClip;
    [SerializeField]
    private Text scoreText;
    public int score = 0;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bridIsAlive = true;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //di chuyển nhân vật có Physic
        BridFlappy();
	
	}
    void BridFlappy()
    {
        if (bridIsAlive)
        {
            Vector3 temp = transform.position;//lấy vị trí của Brid
            temp.x = temp.x + moveForce * Time.deltaTime;
            transform.position = temp;
            //brid jump
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(0, bounceForce);
                audioSource.PlayOneShot(flapClip);
                anim.SetTrigger("Flap");
            }
            if (myBody.velocity.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (myBody.velocity.y < 0)
            {
                float angle = 0f;
                angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7f);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else if (myBody.velocity.y > 0)
            {
                float angle = 0f;
                angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7f);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ground"|| target.gameObject.tag == "PipeHolder")
        {
            if (bridIsAlive)
            {
                bridIsAlive = false;
                anim.SetTrigger("Died");
                audioSource.PlayOneShot(dieClip);
                GamePlayManager.instance.BridDiedShowPanel(score);
               
            }
        }
    }
    public void InscreasementScore(int score)
    {
        scoreText.text = "" + score;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Pipe")
        {
         
            audioSource.PlayOneShot(pingClip);
            score++;
            InscreasementScore(score);
            
           
        }
    }
}
