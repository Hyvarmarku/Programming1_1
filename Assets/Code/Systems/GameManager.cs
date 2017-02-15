using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public enum GameStateType
    {
        Error = -1,
        MenuState,
        InGameState,
        GameOverState
    }

    public enum GameStateTransitionType
    {
        Error = -1,
        MenuToInGame,
        InGameToMenu,
        InGameToGameOver,
        GameOverToMenu
    }

    public class GameManager : MonoBehaviour
    {
        
    }
}
