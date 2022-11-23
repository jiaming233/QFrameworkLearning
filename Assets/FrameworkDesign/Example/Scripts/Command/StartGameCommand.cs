using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class StartGameCommand : ICommand
    {
        public void Execute()
        {
            GameStartEvent.Trigger();
        }
    }
}

