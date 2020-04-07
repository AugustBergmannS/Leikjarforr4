using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float timer = 2f;
    public Text countText;
    private int count = 0;
    public Collider2D onCollision;

    public GameObject rb;

    public float runSpeed = 20f;
    float moveh = 0f;
    bool jump = false;
    bool crouch = false;


        


    void Update()
    {
        moveh = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(moveh));
        

        timer += Time.deltaTime;
        if (timer >= 2f)
        { 
            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJump", true);
            }
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouch", false);
        }
        if (rb.transform.position.y < -1.4f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void OnTriggerEnter2D()
    {
        if (onCollision.gameObject.CompareTag("Pick Up"))
        {
            onCollision.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }


    void SetCountText()
    {
        countText.text = "" + count.ToString();
    }

        public void OnLand()
    {
  
            animator.SetBool("IsJump", false);

    }

    void FixedUpdate()
    {
        controller.Move(moveh * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
