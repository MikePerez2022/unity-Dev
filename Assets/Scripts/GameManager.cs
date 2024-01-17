using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;


    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    public int Lives 
    {  
        get { return lives; }
        set 
        { 
            lives = value; 
            livesUI.text = "Lives: " + lives.ToString(); 
        }
    }
    public float Timer 
    { 
        get { return timer; } 
        set 
        { 
            timer = value; 
            timerUI.text = string.Format("{0:F1}", timer); 
        } 
    }

    public void startGame()
    {
        state = State.START_GAME;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }

    private void OnEnable()
    {
        scoreEvent.Subscribe(OnAddPoints);
    }

    private void OnDisable() 
    {
        scoreEvent.Unsubscribe(OnAddPoints);
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch(state) 
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaisedEvent();
                Timer = 60;
                Lives = 3;
                state = State.PLAY_GAME;
                break; 
            case State.PLAY_GAME:
                Timer = timer - Time.deltaTime;
                if(timer <= 0)
                {
                    state = State.GAME_OVER;
                }
                break ; 
            case State.GAME_OVER:
                break ;
            default:
                break;
        }

        healthUI.value = health.Value / 100.0f;
    }
}
