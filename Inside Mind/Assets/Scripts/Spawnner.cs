using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{

    [System.Serializable]
    public class Spawn_Points
    {
        public Enemy[] Enemies;
    }

    public Spawn_Points points;
    public Transform[] Points;
    private Transform player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Enemy_Spawnner());
    }

    IEnumerator Enemy_Spawnner()
    {
        Enemy enemy = points.Enemies[Random.Range(0, points.Enemies.Length - 1)];
        Transform Random_Choose = Points[Random.Range(0, Points.Length - 1)];
        yield return new WaitForSeconds(4.0f);
        if (player != null)
        {
            Instantiate(enemy, Random_Choose.position, Quaternion.LookRotation(player.position));

        }
        if (player != null)
        {
            StartCoroutine(Enemy_Spawnner());
        }
    }
}
