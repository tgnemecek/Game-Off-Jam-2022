using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhases
{
    /*
        Start of player's turn; should be transitioned to the
        discard phase after all events are done.
    */
    StartOfTurn,
    /*
        Discard phase where you opt to discard a number of
        cards from your hand
    */
    Discard,
    /*
        Drawing phase where you get as much as the max number of
        cards from your deck (if any still remains there)
    */
    Draw,
    /*
        Playing phase where you use your resources, play cards,
        and generaly do most of the game.
    */
    Play,
    /*
        After you pass there should be end of turn phase where
        the game will be responsible to execute end of turn
        actions.
    */
    EndOfTurn,
    /*
        Enemys turn where you are not able to execute actions.
    */
    EnemyTurn,
}

class GameState : MonoBehaviour
{
    public event Action onStartTurn;
    public event Action onEndTurn;

    public static GamePhases startingPhase;
    public static GameState Instance { get; private set; }
    public GamePhases currentPhase { get; private set; }

    public void nextPhase()
    {
        switch (this.currentPhase)
        {
            case GamePhases.StartOfTurn:
                this.currentPhase = GamePhases.Discard;
                break;
            case GamePhases.Discard:
                this.currentPhase = GamePhases.Draw;
                break;
            case GamePhases.Draw:
                this.currentPhase = GamePhases.Play;
                break;
            case GamePhases.Play:
                this.currentPhase = GamePhases.EndOfTurn;
                this.endTurn();
                break;
            case GamePhases.EndOfTurn:
                this.currentPhase = GamePhases.EnemyTurn;
                break;
            case GamePhases.EnemyTurn:
                this.currentPhase = GamePhases.StartOfTurn;
                this.startTurn();
                break;
        }
    }

    public void startTurn()
    {
        if (this.onStartTurn != null)
        {
            /*
                Invoke all start turn callbacks subscribed like unlocking scenario,
                letting the player to draw card, to choose card, etc.
            */
            this.onStartTurn();
        }
        this.nextPhase();
    }

    public void endTurn()
    {
        if (this.onEndTurn != null)
        {
            /*
                Invoke all end turn callbacks subscribed like resources being produced,
                locking player actions, removing objects, etc.
            */
            this.onEndTurn();
        }
        this.nextPhase();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        this.currentPhase = startingPhase;
    }
}