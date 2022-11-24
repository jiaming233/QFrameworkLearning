namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            /*
            GameModel.Instance.KillCount.Value++;

            if(GameModel.Instance.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
            */

            PointGame.Get<IGameModel>().KillCount.Value++;

            if (PointGame.Get<IGameModel>().KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}
