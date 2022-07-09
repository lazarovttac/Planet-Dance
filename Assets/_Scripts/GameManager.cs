using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene currentScene; 
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start() {
        currentScene = SceneManager.GetActiveScene();
    }

    public void ReloadScene() {
        SceneManager.LoadScene(currentScene.name);
    }
    public void CloseApplication() {
        Application.Quit();
    }
}
