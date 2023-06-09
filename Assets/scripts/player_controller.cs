using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    public float speed;
    public float gravity;
    public float rotSpeed;


    private float rot;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    void Move()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 180, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 135, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 225, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S)==false)
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 90, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)== false && Input.GetKey(KeyCode.S)==false)
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 270, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 0, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 45, 0);
                anim.SetInteger("transition",1);
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                moveDirection = Vector3.forward * speed;
                transform.eulerAngles = new Vector3(0, 315, 0);
                anim.SetInteger("transition",1);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition",0);
            }
            else if(Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition",0);
            }
            else if(Input.GetKeyUp(KeyCode.A))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition",0);
            }
            else if(Input.GetKeyUp(KeyCode.D))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition",0);
            }
        }
        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection);
    }


}
