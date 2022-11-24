namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            Register<IGameModel>(new GameModel());
        }
        /*
         * 
        private static IOCContainer mContainer;

        /// <summary>
        /// ȷ��container��ʵ��
        /// </summary>
        static void MakeSureContainer()
        {
            if (mContainer == null)
            {
                mContainer = new IOCContainer();
                Init();
            }
        }

        /// <summary>
        /// ע��ģ��
        /// </summary>
        static void Init()
        {
            mContainer.Register<GameModel>(new GameModel());
        }

        /// <summary>
        /// ��ȡģ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
        {
            MakeSureContainer();

            return mContainer.Get<T>();
        }
        */
    }
}
