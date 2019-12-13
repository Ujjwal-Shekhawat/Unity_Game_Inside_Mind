using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody playerBod;
    private float Walk_Speed = 1f;
    private bool allowJumping = true;
    public GameObject Hands_Guns;
    private Animator animatio;
    public GameObject End_Screen;
    public enum State {Alive, Dead};

    public State player_state;

    private void Start()
    {
        playerBod = GetComponent<Rigidbody>();
        Hands_Guns = GameObject.FindGameObjectWithTag("Guns");
        animatio = Hands_Guns.GetComponent<Animator>();
        player_state = State.Alive;
    }

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        if (player_state == State.Alive)
        {
            Locomotion(hor, ver);
            Jump();
        }
        Set_Animations(hor, ver);
    }


    void Jump()
    {
        if (Input.GetKeyDown("space") && allowJumping == true)
        {
            playerBod.AddForce(Vector3.up * 70, ForceMode.Impulse);
            print("jump");
        }
    }

    void Locomotion(float Hor, float Ver)
    {
        Vector3 vector = Vector3.forward * Ver + Vector3.right * Hor;
        transform.Translate(vector * 10f * Time.deltaTime);
    }

    void Set_Animations(float Hor, float Ver)
    {
        if (Hor != 0.0f || Ver != 0.0f)
        {
            animatio.SetBool("hasVelocity", true);
        }
        else
        {
            animatio.SetBool("hasVelocity", false);
        }

    }

    public void die()
    {
        transform.DetachChildren();
        player_state = State.Dead;
        End_Screen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        allowJumping = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        allowJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fall_Barrier") == true)
        {
            transform.position = new Vector3(0f, 10f, 0f);
        }
    }
}
