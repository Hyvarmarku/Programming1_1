
namespace TAMKShooter.Systems.States
{
    public class MenuState : GameStateBase
    {
        public override string sceneName
        {
            get
            {
                return Configs.Config.MenuSceneName;
            }
        }

        public MenuState() : base()
        {
            stateType = GameStateType.MenuState;
            AddTransition(GameStateTransitionType.MenuToInGame, GameStateType.InGameState);
        }
    }
}
