using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text levelsText;
    public Animator FadeIn;

    public void Setup(int levelscomplete)
    {
        gameObject.SetActive(true);
        levelsText.text = "Levels completed: " + levelscomplete.ToString() + "/2";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}

