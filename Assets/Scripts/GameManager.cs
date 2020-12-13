using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void EnterLevel()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void ExitGame()
    {
        //yield return new WaitForSeconds(5);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        // works only with built Apps
        // Application.Quit();

    }
}
