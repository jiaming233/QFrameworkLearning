using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        /// <summary>
        /// 注册Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void RegisterModel<T>(T model) where T : IModel;

        /// <summary>
        /// 注册Utility
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void RegisterUtility<T>(T utility);

        /// <summary>
        /// 获取Utility
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetUtility<T>() where T : class;
    }

    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化过
        /// </summary>
        private bool mInited = false;
        /// <summary>
        /// 将要初始化的IModel
        /// </summary>
        private List<IModel> mModels = new List<IModel>();

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture;



        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                //注册模块
                mArchitecture.Init();
            }

            OnRegisterPatch?.Invoke(mArchitecture);

            foreach(var architectureModel in mArchitecture.mModels)
            {
                architectureModel.Init();
            }
            mArchitecture.mModels.Clear();
            mArchitecture.mInited = true;
        }

        protected abstract void Init();

        private IOCContainer mContainer = new IOCContainer();

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        /// <summary>
        /// Model属于某个Architecture
        /// 通过Architecture获取Utility
        /// 绕开单例实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public void RegisterModel<T>(T model) where T : IModel
        {
            model.Architecture = this;
            mContainer.Register<T>(model);

            if (!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
        }

        public void RegisterUtility<T>(T utility)
        {
            mContainer.Register<T>(utility);
        }

        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }
    }
}

