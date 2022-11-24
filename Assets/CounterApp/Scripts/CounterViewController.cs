using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private ICounterModel mCounterModel;
        void Start()
        {
            //CounterModel.Instance.Count.OnValueChanged += OnCountChanged;
            mCounterModel = CounterApp.Get<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            //主动调用一次
            OnCountChanged(mCounterModel.Count.Value);

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                new AddCountCommand().Execute();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                new SubCountCommand().Execute();
            });
        }

        void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            //CounterModel.Instance.Count.OnValueChanged -= OnCountChanged;
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel : ICounterModel//: Singleton<CounterModel>
    {
        //v1 singleton
        //private CounterModel() { }

        //v2 引入IOC
        /*
        public BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
        */

        //v4 支持数据存储
        /*
        public CounterModel()
        {
            var storage = CounterApp.Get<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count => storage.SaveInt("COUNTER_COUNT", count);
        }
        */

        //v5 替代构造方法
        public void Init()
        {
            //CounterApp作为Architecture单例，Get时MakeSure
            //初次调用会执行Init(), Init()在子类中进行模块注册
            //CounterApp Init()中调用了CounterModel的构造方法
            //造成了递归

            //也就是说，是在尝试从Model中访问Utility层时出现的问题
            //var storage = CounterApp.Get<IStorage>();
            //绕开单例的初始化

            //RegistModel传入CounterModel后才对Architecture赋值
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count => storage.SaveInt("COUNTER_COUNT", count);
        }

        //v3 IOC注册接口模块
        public BindableProperty<int> Count { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public IArchitecture Architecture { get; set; }


    }
}

