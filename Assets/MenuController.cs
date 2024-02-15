using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void NextLevel(string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
