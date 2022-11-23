using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown() 
        {
            Destroy(gameObject);

            //v1 由Enemy判断游戏是否结束,不符合单一职责原则
            /*
            GameModel.KillCount++;
            if (GameModel.KillCount == 10)
            {
                GamePassEvent.Trigger();
            }
            */

            //v2 事件
            //KilledOneEnemyEvent.Trigger();

            //v3 引入BindableProperty, 数据驱动 自动触发表现逻辑
            //GameModel.KillCount.Value++;

            //v4 引入Command
            new KillEnemyCommand().Execute();
        }
    }
}
