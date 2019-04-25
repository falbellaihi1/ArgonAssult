using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;
    Scoreboard _scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddTriggerBoxCollider();
        _scoreBoard = FindObjectOfType<Scoreboard>();
    }

    private void AddTriggerBoxCollider()
    {
        
       Collider EnemyShipCollider = gameObject.AddComponent<BoxCollider>();
        EnemyShipCollider.isTrigger = false;
        ///EnemyShipCollider.SendMessage
    }

    private void OnParticleCollision(GameObject other)
    {
        hits--;
        _scoreBoard.ScoreHit(scorePerHit);
        if(hits <=1)
        {
            KillEnemy();

        }

    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
