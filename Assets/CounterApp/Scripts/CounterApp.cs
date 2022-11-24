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
            mContainer.Register<CounterModel>(new CounterModel());
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
