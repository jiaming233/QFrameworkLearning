using FrameworkDesign;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            //RegisterModel<ICounterModel>(new CounterModel());
            Register<ICounterModel>(new CounterModel());
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
        /*
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
            mContainer.Register<CounterModel>(new CounterModel());
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
