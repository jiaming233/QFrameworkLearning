using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameworkDesign;

namespace CounterApp
{
    //ʹ�ýṹ�� �ڴ����Ч�ʸ���
    public struct AddCountCommand : ICommand
    {
        public void Execute()
        {
            //CounterModel.Instance.Count.Value++;
            CounterApp.Get<ICounterModel>().Count.Value++;
        }
    }
}

