using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //have to add this line to use SceneManager

public class GameEnding : MonoBehaviour
{

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup; //if win 
    public AudioSource exitAudio;
  
    public AudioSource caughtAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup; //if got caught by Gargoyle

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other) //if player enters the exit
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer() // if he is caught by Gargoyle
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio); //if win then exit the game
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio); //if caught by Gargoyle then restart the game
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0); //load first scene aka our only scene
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
