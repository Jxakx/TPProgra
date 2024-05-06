using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayCanvasManager : MonoBehaviour
{
    public GameObject losePanel, winPanel;
    void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    
    public void onLose()
    {
        losePanel.SetActive(true);
        winPanel.SetActive(false);
        
    }

    public void onWin()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(true);
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
