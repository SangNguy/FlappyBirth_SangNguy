using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;

    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip,diedClip ;

    //khi bird alive thi van co the tap cho bird bay len
    private bool isAlive; 
    private bool didFlap;
    private GameObject spawner;

    public float flag = 0;
    public int score = 0;

    // ~~ Start, Awake khoi tao cac bien duoc su dung cho bird
    void Awake ()
    {
        isAlive = true; // vi isAlive khoi tao bang bool nen mac dinh cua no la false
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        _MakeInstance(); 
        spawner = GameObject.Find("Spawner Pipe");
    }


    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }

    //su dung tren man hinh cam ung
    void _BirdMoveMent()
    {

        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;

                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce); //click de bird nay len
               
                audioSource.PlayOneShot(flyClip); //am thanh khi click bay
            }
        }


        //su dung chuot
        if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
            //am thanh khi click bay
            audioSource.PlayOneShot(flyClip);
        }
        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            //bird chia dau len khi click
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            //bird chui dau xuong khi khong click
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            score++;
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(score); //get diem vao text khi bird qua pipe
            }
            audioSource.PlayOneShot(pingClip); //phat tieng ping khi bay qua ong nuoc
        }
    }
     void OnCollisionEnter2D(Collision2D target)
    {

        //Bird die khi va cham vao pipe hoac ground
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            //dong bang man hinh game sau khi died
            if (isAlive)
            {
            isAlive = false;
            Destroy(spawner); 
            audioSource.PlayOneShot(diedClip);
            anim.SetTrigger("Died");
                //Time.timeScale = 0;
            }
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._BirdDiedShowPanel(score); //get diem len panel died
            }
        }
    }
}
