using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    [Header("Game Objects")]
    public GameObject ArrowUP;
    public GameObject ArrowDOWN;
    public GameObject ArrowLEFT;
    public GameObject ArrowRIGHT;

    [Header ("Audio Elements")]
    public AudioSource audioSource;
    public AudioClip rightSound;
    public AudioClip upSound;
    public AudioClip downSound;
    public AudioClip leftSound;
    public AudioClip failSound;


    void Start()
    {
        gameObject.transform.position = GameObject.Find("Paths").transform.GetChild(0).transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
         
        ArrowsAnimations();
   
    }

    void ArrowsAnimations() 
    {
        ArrowRIGHT.GetComponent<Animator>().SetInteger("Tempo", GameController.gameController.GetTempo());
        ArrowUP.GetComponent<Animator>().SetInteger("Tempo", GameController.gameController.GetTempo());
        ArrowDOWN.GetComponent<Animator>().SetInteger("Tempo", GameController.gameController.GetTempo());
        ArrowLEFT.GetComponent<Animator>().SetInteger("Tempo", GameController.gameController.GetTempo());
    }

    public void Movement()
    {
        if(GameController.gameController.GetTempo() == 4)
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(leftSound);
            ArrowUP.GetComponent<BoxCollider2D>().enabled = false;
            ArrowDOWN.GetComponent<BoxCollider2D>().enabled = false;
            ArrowLEFT.GetComponent<BoxCollider2D>().enabled = true;
            ArrowRIGHT.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (GameController.gameController.GetTempo() == 3)
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(rightSound);
            ArrowUP.GetComponent<BoxCollider2D>().enabled = false;
            ArrowDOWN.GetComponent<BoxCollider2D>().enabled = false;
            ArrowLEFT.GetComponent<BoxCollider2D>().enabled = false;
            ArrowRIGHT.GetComponent<BoxCollider2D>().enabled = true;

        }
        if (GameController.gameController.GetTempo() == 1)
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(upSound);
            ArrowUP.GetComponent<BoxCollider2D>().enabled = true;
            ArrowDOWN.GetComponent<BoxCollider2D>().enabled = false;
            ArrowLEFT.GetComponent<BoxCollider2D>().enabled = false;
            ArrowRIGHT.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (GameController.gameController.GetTempo() == 2)
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(downSound);
            ArrowUP.GetComponent<BoxCollider2D>().enabled = false;
            ArrowDOWN.GetComponent<BoxCollider2D>().enabled = true;
            ArrowLEFT.GetComponent<BoxCollider2D>().enabled = false;
            ArrowRIGHT.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    public void DisableColliders()
    {
        ArrowUP.GetComponent<BoxCollider2D>().enabled = false;
        ArrowDOWN.GetComponent<BoxCollider2D>().enabled = false;
        ArrowLEFT.GetComponent<BoxCollider2D>().enabled = false;
        ArrowRIGHT.GetComponent<BoxCollider2D>().enabled = false;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NextPath" && collision.gameObject.name==GameController.gameController.nextPath  || collision.gameObject.name == GameController.gameController.previousPath)
        {
            gameObject.transform.position = collision.transform.position;
            DisableColliders();
        }

        if (collision.gameObject.tag == "Block")
        {
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(failSound);
            DisableColliders();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        GameController.gameController.InstantiateEnemy(collision.gameObject.name);
        if (gameObject.transform.position == collision.transform.position)
        {
            //collision.gameObject.tag = "CurrentPath";
            GameController.gameController.changePathTags(collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(GameController.gameController.PathManager(collision.gameObject.name) == collision.gameObject.name)
        //collision.gameObject.tag = "NextPath";
    }
    
}
