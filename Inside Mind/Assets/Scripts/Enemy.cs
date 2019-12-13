using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    public GameObject Death_Effect;
    private player player_script;
    private void Start()
    {
        player_script = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<player>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player_script.player_state == global::player.State.Alive)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            transform.LookAt(player.transform);
        }
    }

    public void Kill()
    {
        Instantiate(Death_Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        player character = collision.collider.transform.GetComponent<player>();
        if (character != null)
        {
            character.die();
            Instantiate(Death_Effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
