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

            //v1 ��Enemy�ж���Ϸ�Ƿ����,�����ϵ�һְ��ԭ��
            /*
            GameModel.KillCount++;
            if (GameModel.KillCount == 10)
            {
                GamePassEvent.Trigger();
            }
            */

            //v2 �¼�
            //KilledOneEnemyEvent.Trigger();

            //v3 ����BindableProperty, �������� �Զ����������߼�
            //GameModel.KillCount.Value++;

            //v4 ����Command
            new KillEnemyCommand().Execute();
        }
    }
}
