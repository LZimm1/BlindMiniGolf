using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static int bounceCount;
    public Rigidbody2D mybody;
    public AudioSource bounce;
    public static bool nextLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("LRWall")){
            bounceCount++;
            if(bounceCount == 1){
                Aim.velX *= -1;
                mybody.velocity = new Vector2(Aim.velX, Aim.velY);
                bounce.Play();
            }
            else{
                Aim.velX *= -1;
                mybody.velocity = new Vector2(Aim.velX,Aim.velY);
                bounce.Play();
            }
        }
        else if(collision.gameObject.CompareTag("TBWall")){
            bounceCount++;
            if(bounceCount == 1){
                Aim.velY *= -1;
                mybody.velocity = new Vector2(Aim.velX, Aim.velY);
                bounce.Play();
            }
            else{
                Aim.velY *= -1;
                mybody.velocity = new Vector2(Aim.velX,Aim.velY);
                bounce.Play();
            }
        }
        else if(collision.gameObject.CompareTag("Hole")){
            nextLevel = true;
        }
        else if(collision.gameObject.CompareTag("Sandtrap")){
            Destroy(gameObject);
        }
    }
    
}
