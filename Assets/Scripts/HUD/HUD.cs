using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text _finalScores;
    [SerializeField]
    private Text Scores;
    [SerializeField]
    private Image _loseWindow;
    private bool _pause = false;

    public void ChangeScores()
    {
        Scores.text = GameController.Instance.Player.Scores.ToString();
    }

    public void Pause(bool trigger)
    {
        _pause = trigger;
        if (_pause)
        {
            Time.timeScale = 0.0f;
        }
        else if (!_pause)
        {
            Time.timeScale = 1f;

        }
    }

    public void LoseWindowShow()
    {
        Pause(true);
        _loseWindow.gameObject.SetActive(true);
        StartCoroutine(GameOverPanelFade());
    }

    IEnumerator GameOverPanelFade()
    {
        float time = 5f;
        float maxValue = 1f;
        float minValue = 0f;
        float deltaTime = maxValue / 100 * time;
        var color = _loseWindow.color;
        color.a = minValue;
        _loseWindow.color = color;
        while (_loseWindow.color.a < 1f)
        {
            color = _loseWindow.color;
            color.a += deltaTime;
            _loseWindow.color = color;
            yield return null;// new WaitForSeconds(deltaTime); 
        }
    }

    public void LoadGame()
    {
        Pause(false);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SetScores()
    {
        string scores = GameController.Instance.Player.Scores.ToString();
        _finalScores.text = scores + " scores";
    }
}
