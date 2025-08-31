using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuideMovement : MonoBehaviour
{
    public bool canMove = false;
    public int i = 0;
    void Start()
    {
        this.gameObject.transform.position = GameObject.Find("Paths").transform.GetChild(0).transform.position;
    }


    void Update()
    {
        GuideThePlayer();
    }

    public void GuideThePlayer()
    {
        if (i == GameObject.Find("Paths").transform.childCount - 1)
        {
            Debug.Log("FinalPath Reached");
            Destroy(gameObject);

        }
        if (GameController.gameController.guideTempo == 4.0f)
        {
            canMove = true;
            if (canMove)
            {
                if (i <= GameObject.Find("Paths").transform.childCount - 1)
                {
                    GameController.gameController.guideTempo = 0;
                    canMove = false;
                    gameObject.transform.position = GameObject.Find("Paths").transform.GetChild(i+1).transform.position;
                    i++;
                }
            }
            
            canMove = false;
        }
        return;
    }
}
