using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Aim : MonoBehaviour
{
    public static float ballSpeed = 10f;
    
    public static int strokeCount = 0;
    public static int totalStrokeCount = 0;
    private Vector3 mousePos;
    public GameObject line;
    public GameObject ball;
    public GameObject offScreen;
    public Rigidbody2D mybody;

    public AudioSource hit;

    public static bool ready = true;
    public static float velX = 0f;
    public static float velY = 0f;
    Vector3 difference;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mybody){
            if(ready){
                line.transform.position = ball.transform.position;
            }
            else{
                line.transform.position = offScreen.transform.position;
            }
            mousePos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            difference = line.transform.position - mousePos;
            float rotationZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) -45;
            line.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            MoveBall(difference);
            velX = mybody.velocity.x;
            velY = mybody.velocity.y;
            if(mybody.velocity == Vector2.zero){
                ready = true;
            }
        }
    }
    void MoveBall(Vector3 difference){
        if(Input.GetButtonDown("Jump") && ready){
            hit.Play();
            velX = difference.x * ballSpeed /3;
            velY = difference.y * ballSpeed /3;
            mybody.velocity = new Vector2(-velX,-velY);
            ready = false;
            strokeCount++;
        }
    }
    
    
}
