using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public MovePlayer Player;
    public HUD HUD;

    public UnityEvent 
        UIUpdate,
        GameOver;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        if (UIUpdate != null)
            UIUpdate.Invoke();
    }
    private void Update()
    {
        if (UIUpdate != null)
            UIUpdate.Invoke();
    }

}
