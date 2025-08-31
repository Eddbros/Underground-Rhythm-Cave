using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool canMove=false;
    public int i = 0;
    void Start()
    {
        this.gameObject.transform.position= GameObject.Find("Paths").transform.GetChild(0).transform.position;
    }

    
    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (i == GameObject.Find("Paths").transform.childCount - 1)
        {
            Debug.Log("FinalPath Reached");
                Destroy(gameObject);
            
        }
        if (GameController.gameController.enemyTempo == 12.0f)
        {
            canMove = true;
            if (canMove)
            {
                if (i <= GameObject.Find("Paths").transform.childCount - 1)
                {
                    GameController.gameController.enemyTempo = 0;
                    canMove = false;
                    gameObject.transform.position = GameObject.Find("Paths").transform.GetChild(i+1).transform.position;
                    i++;
                }
            }
            canMove = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            ChangingScenes.instance.ReloadScene();
        }
    }
}
