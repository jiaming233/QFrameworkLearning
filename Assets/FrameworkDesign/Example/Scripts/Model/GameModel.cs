namespace FrameworkDesign.Example
{
    public class GameModel
    {
        //����� ���ֺ����ݷ���
        /*
        public static int KillCount = 0;

        public static int Gold = 0;

        public static int Score = 0;

        public static int BestScore = 0;
        */

        //�ڰ˿� ����BindableProperty
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