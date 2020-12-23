using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFast : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private float positionDown;
    private float positionUp;

    public bool isMovingUp = true;
    public SpriteRenderer spriteR;
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        positionDown = gameObject.transform.position.y - distance;
        positionUp = gameObject.transform.position.y + distance;
    }

    // Update is called once per frame
    void Update()
    {
          if (isMovingUp == true){
            gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else{
            gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if(transform.position.y >= positionUp){
            isMovingUp  = false;
        }

        if(transform.position.y <= positionDown){
            isMovingUp = true;
        }

    }
}