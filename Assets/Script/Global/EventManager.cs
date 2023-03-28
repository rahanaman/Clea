using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace Event
{
    namespace ����
    {
        public delegate void TEvent<T>(T t);
        public static class ����EventManager
        {//�Լ� �ɰ� ���� ��� �ɰ� ������ TriggerID�� Ž���ϰ�, ȣ���� ���� TriggerID�� ȣ������~

            public static Action[] PlayerTrigger = new Action[Enum.GetValues(typeof(TriggerID)).Length];

            public static void ResetPlayerTrigger()
            {
                PlayerTrigger = new Action[Enum.GetValues(typeof(TriggerID)).Length];
            }
            public static void CallOnPlayerTrigger(TriggerID id)
            {
                PlayerTrigger[(int)id].Invoke();
            }
            
            public static void AddPlyerTrigger(TriggerID id, Action action)
            {
                PlayerTrigger[(int)id] += action;
                
            }

            public static void RemovePlayerTrigger(TriggerID id, Action action)
            {
                PlayerTrigger[(int)id] -= action;
            }

            public static List<Action[]> EnemyTrigger = new List<Action[]>();

            public static void ResetEnemyTrigger()
            {
                EnemyTrigger = new List<Action[]>();
            }

            public static void CallOnEnemyTrigger(int index, TriggerID id) // ȣ��
            {
                EnemyTrigger[index][(int)id].Invoke();
            }
            public static int AddEnemyTrigger() //���� ���� ���, ���� ������ �� ȣ���ؾ��ϴ� ��
            {
                int index = EnemyTrigger.Count;
                EnemyTrigger.Insert(index, new Action[Enum.GetValues(typeof(TriggerID)).Length]);
                return index;
            }
            public static void RemoveEnemyTrigger(int index)
            {
                if (0 <= index && index < EnemyTrigger.Count)
                {
                    EnemyTrigger.RemoveAt(index);
                }
            }
        }
    }
    
}





