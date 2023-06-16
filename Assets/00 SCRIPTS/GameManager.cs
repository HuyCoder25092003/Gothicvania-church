using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [SerializeField]GAMESTATE gameState;
    public GAMESTATE GameState { get => gameState; set => gameState = value; }
    // Start is called before the first frame update
    void Start()
    {
        PlayButton play= new PlayButton();
        play.playButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
