using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //ʹ��ί�еķ�ʽ
            //CounterModel.OnCountChanged += OnCountChanged;
            CounterModel.Count.OnValueChanged += OnCountChanged;
            //ʹ���¼��ķ�ʽ
            //OnCountChangedEvent.Register(OnCountChanged);

            /*
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //�����߼�
                //CounterModel.Count++;
                //�����߼�
                //UpdateView();

                //�����߼� �Զ����������߼�
                CounterModel.Count.Value++;
            });
            */

            //�ھſ� ����Command
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                new AddCountCommand().Execute();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                new SubCountCommand().Execute();
            });
        }

        void UpdateView()
        {
            //�������õĽ�����ʽ
            transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }

        void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            //CounterModel.OnCountChanged -= OnCountChanged;
            CounterModel.Count.OnValueChanged -= OnCountChanged;
            //OnCountChangedEvent.UnRegister(OnCountChanged);
        }
    }

    public static class CounterModel
    {
        public static BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
        /*
        private static int mCount = 0;

        public static Action<int> OnCountChanged;

        public static int Count
        {
            get
            {
                return mCount;
            }
            set
            {
                if(value != mCount)
                {
                    mCount = value;

                    OnCountChanged?.Invoke(mCount);

                }
            }
        }


        public class OnCountChangedEvent : Event<OnCountChangedEvent>
        {
            
        }
        */
    }
}

