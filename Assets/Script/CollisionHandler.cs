using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Second")][SerializeField]float LevelLoadDelay = 1f;
    [Tooltip("FX Prefab on player death ")][SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", LevelLoadDelay);
    }

    private void StartDeathSequence()
    {
        print("player dying");
        SendMessage("OnPlayerDeath");


    }
    private void ReloadScene() // string reference
    {
        SceneManager.LoadScene(1);
    }

}
