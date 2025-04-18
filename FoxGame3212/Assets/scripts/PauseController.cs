using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _isPaused;

    void Start()
    {
        _isPaused = false;
    }

    
    void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        _pausePanel.SetActive(_isPaused);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
        }
    }

    public void Continue()
    {
        _isPaused = !_isPaused;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
