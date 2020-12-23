using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private float positionLeft;
    private float positionRight;

    public bool isMovingRight = true;
    public SpriteRenderer spriteR;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        positionLeft = gameObject.transform.position.x - distance;
        positionRight = gameObject.transform.position.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight == true){
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else{
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(transform.position.x >= positionRight){
            spriteR.flipX = false;
            isMovingRight  = false;
        }

        if(transform.position.x <= positionLeft){
            spriteR.flipX = true;
            isMovingRight = true;
        }
    }
}