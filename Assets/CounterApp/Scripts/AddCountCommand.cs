using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameworkDesign;

namespace CounterApp
{
    //使用结构体 内存管理效率更高
    public struct AddCountCommand : ICommand
    {
        public void Execute()
        {
            //CounterModel.Instance.Count.Value++;
            CounterApp.Get<ICounterModel>().Count.Value++;
        }
    }
}

