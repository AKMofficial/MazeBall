using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLEVEL : MonoBehaviour
{
    // Audio
    [SerializeField] AudioClip Winning; [SerializeField] AudioClip Lossing; [SerializeField] AudioClip Crashed; [SerializeField] AudioClip BabyBlueBalls;
    AudioSource audioSource;
    void Start(){audioSource=GetComponent<AudioSource>();}

    // Effects
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;


    // Counting
    int WallsHits=0;
    int hits = 0;

    private void OnCollisionEnter(Collision other) 
    { 
    if(other.gameObject.tag == "Walls") 
    {
        audioSource.PlayOneShot(Crashed);
        GetComponent<MeshRenderer>().material.color = Color.black;
        WallsHits++; 
        if (WallsHits==1){Debug.Log("You have 2 lives remaining!");} if (WallsHits==2){Debug.Log("You have 1 live remaining!");} if (WallsHits==3){Debug.Log("You lost :(");}
        if (WallsHits==3){lostSequence();} // Reload Level
    }

    if(other.gameObject.tag == "BlueBalls")
    {audioSource.PlayOneShot(BabyBlueBalls); hits++;Debug.Log("You have collected: " + hits + "/5 blue balls");      GetComponent<MeshRenderer>().material.color = Color.blue;}


    if(other.gameObject.tag == "Finish") 
    {
        Debug.Log("You have solved the maze successfully!");
        GetComponent<MeshRenderer>().material.color = Color.blue;
        winSequence(); // Load next level
    }

    }

    void ReloadLevel(){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
    void lostSequence()
    {
        audioSource.PlayOneShot(Lossing);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",2f);
    }

    void LoadNextLevel(){SceneManager.LoadScene("Menu");}
    void winSequence()
    {
        audioSource.PlayOneShot(Winning);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",2f);
    }


    void Update() {{if(Input.GetKeyDown(KeyCode.Escape)){SceneManager.LoadScene("Menu");}}} // Escape key

}
