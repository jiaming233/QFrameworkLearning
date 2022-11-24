using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //��������
            var container = new IOCContainer();

            //ע��ʵ��
            container.Register<IBluetoothManager>(new BluetoothManager());

            //�������ͻ�ȡʵ��
            var bluetoothManager = container.Get<IBluetoothManager>();

            bluetoothManager.Connect();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public interface IBluetoothManager
        {
            void Connect();
        }

        public class BluetoothManager : IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("�������ӳɹ�");
            }
        }
    }
}

