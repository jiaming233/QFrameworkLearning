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

            //��������һ��
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

        //v2 ����IOC
        /*
        public BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
        */

        //v4 ֧�����ݴ洢
        /*
        public CounterModel()
        {
            var storage = CounterApp.Get<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count => storage.SaveInt("COUNTER_COUNT", count);
        }
        */

        //v5 ������췽��
        public void Init()
        {
            //CounterApp��ΪArchitecture������GetʱMakeSure
            //���ε��û�ִ��Init(), Init()�������н���ģ��ע��
            //CounterApp Init()�е�����CounterModel�Ĺ��췽��
            //����˵ݹ�

            //Ҳ����˵�����ڳ��Դ�Model�з���Utility��ʱ���ֵ�����
            //var storage = CounterApp.Get<IStorage>();
            //�ƿ������ĳ�ʼ��

            //RegistModel����CounterModel��Ŷ�Architecture��ֵ
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count => storage.SaveInt("COUNTER_COUNT", count);
        }

        //v3 IOCע��ӿ�ģ��
        public BindableProperty<int> Count { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public IArchitecture Architecture { get; set; }


    }
}

