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
        /// 确保container有实例
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
        /// 注册模块
        /// </summary>
        static void Init()
        {
            mContainer.Register<GameModel>(new GameModel());
        }

        /// <summary>
        /// 获取模块
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
