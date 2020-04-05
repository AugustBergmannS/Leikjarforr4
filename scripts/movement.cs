using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController2D controller;

    private float timer = 2f;

    public GameObject rb;

    public float runSpeed = 20f;
    float moveh = 0f;
    bool jump = false;
    bool crouch = false;


        


    void Update()
    {
        moveh = Input.GetAxisRaw("Horizontal") * runSpeed;
        timer += Time.deltaTime;
        if (timer >= 2f)
        { 
            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
                Debug.Log("bbnopp");
            }
        }
        /*else if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }*/
        if(rb.transform.position.y < -1.4f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    void FixedUpdate()
    {
        controller.Move(moveh * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
