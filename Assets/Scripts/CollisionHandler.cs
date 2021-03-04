using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    private void OnTriggerEnter(Collider other) 
    {
        CrashSequence();
    }

    private void CrashSequence()
    {
        GetComponent<PlayerControlles>().enabled = false;
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        // GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject);
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
