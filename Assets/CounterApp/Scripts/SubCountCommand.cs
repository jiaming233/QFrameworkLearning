using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp
{
    public class SubCountCommand : ICommand
    {
        public void Execute()
        {
            //CounterModel.Instance.Count.Value--;
            CounterApp.Get<ICounterModel>().Count.Value--;
        }
    }

}
