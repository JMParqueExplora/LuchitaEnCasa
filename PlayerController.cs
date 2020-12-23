using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalInput = 0f;
    public PlayerMovement movement;
    public bool isAlive = true;
    public GameManager manager;
    public Animator anim;
    public AudioSource  audioS;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip jumpSound;
    public Joystick joy;
    

    void Start()
    {
        
    }

    public void Saltar()
    {
        if(movement.m_Grounded)
                {
                    anim.SetTrigger("up");                    
                    audioS.PlayOneShot(jumpSound, 1f);
                }
            movement.Jump();
    }
    
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal") + joy.Horizontal;
        

        /*
        if (Input.GetMouseButtonDown(0) &&  isAlive == true)
        {
            Saltar();
        }*/

        if (Input.GetKeyDown("up") && isAlive == true)
        {
            Saltar();
        }


        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("isAlive", isAlive);

        if(horizontalInput == 0)
        {
            anim.speed =0.5f;
            anim.SetBool("Move", false);
        }
        else
        {
            if(isAlive && movement.m_Grounded)
            {
                anim.speed = 1 * Mathf.Abs (horizontalInput);
            }
            anim.SetBool("Move", true);
        }
    }

    private void FixedUpdate()
    {
        if(isAlive == true)
        {
            movement.Move(horizontalInput * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cherry"){
           Destroy(collision.gameObject);
           manager.totalcoins++;
           audioS.PlayOneShot(coinSound, 1f);
        }

        if(collision.gameObject.tag == "CheckPoint")
        {
            manager.spawnPoint = collision.gameObject.transform;           
        }

        if(collision.gameObject.tag == "LevelEnd")
        {
            manager.FinishLevel();           
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spikes"){
           Die();
        }

        if(collision.gameObject.tag == "Lobo"){
           Die();
        }

        if(collision.gameObject.tag == "Weak"){
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
           Destroy(collision.transform.parent.gameObject);
        }
    }

    public void Die(){
        isAlive = false;
        anim.SetTrigger("Die");
        audioS.PlayOneShot(hurtSound, 0.5f);
        movement.Move(horizontalInput * 0 * Time.deltaTime);
        
    }
}
