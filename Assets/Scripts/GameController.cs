using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    //int lifes = 3;
    
    float timer;
    public int tempo =1;
    public int enemyTempo=1;
    public int guideTempo = 1;
    public bool enemyStatus = true;
    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject guidePrefab;

    [Header("Paths of the level")]
    //public GameObject[] paths;
    public string currentPath;
    public string previousPath;
    public string nextPath;


    private void Awake()
    {
        
        if (gameController != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameController = this;
            DontDestroyOnLoad(this);
        }

        Instantiate(guidePrefab, GameObject.Find("Paths").transform.GetChild(0).transform.position, Quaternion.identity);

    }
    public bool life = true;
    void Update()
    {

        
        timer += Time.deltaTime;
        
        if (timer >= 0.25f)
        {    
            timer = 0;
            tempo += 1;
            enemyTempo += 1;
            guideTempo += 1;   
        }

        Tempo();
    }
        
    public void Tempo()
    {
        if (tempo >= 5)
        {
            tempo = 1;
        }
        if (enemyTempo >= 13)
        {
            enemyTempo = 1;
        }
        if(guideTempo >= 5)
        {
            guideTempo = 1;
        }
    }

    public int GetTempo()
    {
        return tempo;
    }

    public string PathManager (string path)
    {
        for(int i = 0;i <= GameObject.Find("Paths").transform.childCount;i++ )
        {
            if (GameObject.Find("Paths").transform.GetChild(i).name == path)
            {
                return GameObject.Find("Paths").transform.GetChild(i).name;
            }
        }
        return "Is not in the list";
    }

    public string changePathTags (string path)
    {

        for (int i = 0; i < GameObject.Find("Paths").transform.childCount ; i++)
            {
                if (path == GameObject.Find("Paths").transform.GetChild(0).name)
                {
                    Debug.Log(GameObject.Find("Paths").transform.childCount);
                    Debug.Log("Enter first if");
                    currentPath = path;
                    nextPath = GameObject.Find("Paths").transform.GetChild(i + 1).name;
                    GameObject.Find("Paths").transform.GetChild(i).gameObject.tag = "CurrentPath";
                    GameObject.Find("Paths").transform.GetChild(i + 1).gameObject.tag = "NextPath";
                    return currentPath;

                }
                if (path == GameObject.Find("Paths").transform.GetChild(i).name)
                {
                    Debug.Log("Enters this 2 if");
                    currentPath = path;
                    if (i < GameObject.Find("Paths").transform.childCount-1)
                    {
                       
                        nextPath = GameObject.Find("Paths").transform.GetChild(i + 1).name;
                        previousPath = GameObject.Find("Paths").transform.GetChild(i - 1).name;
                        GameObject.Find("Paths").transform.GetChild(i + 1).gameObject.tag = "NextPath";
                        GameObject.Find("Paths").transform.GetChild(i - 1).gameObject.tag = "NextPath";
                    }
                if (i == GameObject.Find("Paths").transform.childCount-1)
                {
                    Debug.Log("FINISHED");

                    ChangingScenes.instance.ChangeLevels("Level2_Scene");

                    //break;
                }
            }
            }
        return path;
    }

    public void InstantiateEnemy(string path)
    {
        
        if(path == GameObject.Find("Paths").transform.GetChild(4).gameObject.name &&enemyStatus)
        {
            enemyStatus = false;
            enemyTempo = 0;
            Instantiate(enemyPrefab, GameObject.Find("Paths").transform.GetChild(0).transform.position, Quaternion.identity);
        }
        
        
    }
}
