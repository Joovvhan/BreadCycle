using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    int currentCheckPointIndex = 0;

    private void Awake()
    {
        if(FindObjectsOfType<Respawner>().Length > 1)
        {
            Destroy(gameObject);
        }    
        else
        {
            PlayerPrefs.SetInt("CheckPoint", 0);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        currentCheckPointIndex = 0;
        
        // RespawnBread();
    }

    public void RespawnBread()
    {
        SceneManager.LoadScene(0);

        //FindObjectOfType<CheckPoints>().SetBreadPos(currentCheckPointIndex);
    }

    public Vector3 GetBreadPos()
    {
        currentCheckPointIndex = PlayerPrefs.GetInt("CheckPoint");
        return FindObjectOfType<CheckPoints>().GetBreadPos(currentCheckPointIndex);
    }

    public void SetCheckPoint(int index)
    {
        currentCheckPointIndex = index;
        PlayerPrefs.SetInt("CheckPoint", currentCheckPointIndex);
    }
}
