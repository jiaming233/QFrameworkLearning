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
            //创建容器
            var container = new IOCContainer();

            //注册实例
            container.Register<IBluetoothManager>(new BluetoothManager());

            //根据类型获取实例
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
                Debug.Log("蓝牙连接成功");
            }
        }
    }
}

