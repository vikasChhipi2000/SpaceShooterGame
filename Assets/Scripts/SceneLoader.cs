using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void playClick()
    {
        SceneManager.LoadScene(1);
    }

    public void playAgainClick()
    {
        FindObjectOfType<GameSession>().resetScore();
        SceneManager.LoadScene(1);
    }

    public void quitClick()
    {
        Application.Quit();
    }

    public void gameOver()
    {
        StartCoroutine(waitForSomeSecond());

    }

    IEnumerator waitForSomeSecond()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(2);
    }
}
