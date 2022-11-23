using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameStartEvent.Register(OnGameStart);

            //�����
            //KilledOneEnemyEvent.Register(OnKilledEnemy);

            //�ڰ˿�
            GameModel.KillCount.OnValueChanged += OnKilledEnemy;
        }


        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        //private void OnKilledEnemy()
        private void OnKilledEnemy(int killCount)
        {
            //GameModel.KillCount.Value++;

            if (killCount == 10)
            {
                //������Ϸͨ���¼�
                //GamePassEvent.Trigger();

                new PassGameCommand().Execute();
            }
        }

        void OnDestroy() 
        {
            GameStartEvent.UnRegister(OnGameStart);

            //KilledOneEnemyEvent.UnRegister(OnKilledEnemy);

            GameModel.KillCount.OnValueChanged -= OnKilledEnemy;
        }
    }
}
