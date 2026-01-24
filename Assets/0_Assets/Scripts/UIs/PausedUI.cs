using System;
using UnityEngine;
using UnityEngine.UI;

public class PausedUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private Button resumeButton;

    //
    [SerializeField] private bool pausedPanelToggle;
 
    void Awake()
    {
        // it cause confliction at GameManager
        //resumeButton.onClick.AddListener( () => OnMenuButtonPressed(this, EventArgs.Empty) );


        resumeButton.onClick.AddListener(OnResumeButtonPressed );
    }

    void Start()
    {
        pausedPanelToggle = false;

        pausedPanel.SetActive(pausedPanelToggle);

        // prefer this way then get from GameManager for decouple
        InputReader.Instance.OnMenuButtonPressed += OnMenuButtonPressed;
    }

    private void OnMenuButtonPressed(object sender, EventArgs e)
    {
        // toggle PausedPanel
        pausedPanelToggle = !pausedPanelToggle;

        pausedPanel.SetActive(pausedPanelToggle);
    }

    private void OnResumeButtonPressed()
    {
        GameManager.Instance.ResumeGame();
        OnMenuButtonPressed(this, EventArgs.Empty);
        
    }


}
