using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{

    private float Mouse_Scensitivity = 100f;
    private Transform playerBod;
    private float timebetewnshots = 0f;
    public GameObject arms;
    private float X_Rotation = 0.0f;
    private float Y_Rotation = 0.0f;
    public GameObject hitEffect;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBod = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        float Mouse_X = Input.GetAxis("Mouse X") * Mouse_Scensitivity * Time.deltaTime;
        float Mouse_Y = Input.GetAxis("Mouse Y") * Mouse_Scensitivity * Time.deltaTime;

        X_Rotation -= Mouse_Y;
        X_Rotation = Mathf.Clamp(X_Rotation, -90f, 90f);

        Y_Rotation += Mouse_X;

        transform.localRotation = Quaternion.Euler(X_Rotation, 0f, 0f);
        
        if (playerBod != null)
        {
            playerBod.Rotate(Vector3.up * Mouse_X);
            if (Input.GetMouseButton(0) && Time.time > timebetewnshots)
            {
                timebetewnshots = timebetewnshots + 0.5f;
                Shoot();
            }
        }

        else if (playerBod == null)
        {
            transform.localRotation = Quaternion.Euler(X_Rotation, Y_Rotation, 0f);
        }

        if (transform.parent == null)
        {
            Destroy(arms);
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1000f))
        {
            if (hitInfo.rigidbody != null)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Kill();
                }
            }

            if (hitInfo.transform != null)
            {
            Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
        
    }
}
