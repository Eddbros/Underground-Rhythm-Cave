using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class ChangingScenes : MonoBehaviour
{   
    public static ChangingScenes instance;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1_Scene");
    }

    public void Level2()
    {
        GameController.gameController.enemyStatus = true;
        SceneManager.LoadScene("Level2_Scene");
    }

    public void ChangeLevels(string level)
    {
        GameController.gameController.enemyStatus = true;
        SceneManager.LoadScene(level);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
