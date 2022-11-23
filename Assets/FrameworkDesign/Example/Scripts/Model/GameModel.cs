namespace FrameworkDesign.Example
{
    public class GameModel
    {
        //第五课 表现和数据分离
        /*
        public static int KillCount = 0;

        public static int Gold = 0;

        public static int Score = 0;

        public static int BestScore = 0;
        */

        //第八课 引入BindableProperty
        public static BindableProperty<int> KillCount = new BindableProperty<int>
        {
            Value = 0
        };

        public static BindableProperty<int> Gold = new BindableProperty<int>
        {
            Value = 0
        };

        public static BindableProperty<int> Score = new BindableProperty<int>
        {
            Value = 0
        };

        public static BindableProperty<int> BestScore = new BindableProperty<int>
        {
            Value = 0
        };
    }
}