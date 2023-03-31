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
        public delegate void TriggerEvent (CreatureController t);
        public static class ����EventManager
        {//�Լ� �ɰ� ���� ��� �ɰ� ������ TriggerID�� Ž���ϰ�, ȣ���� ���� TriggerID�� ȣ������~

            public static TriggerEvent[] PlayerTrigger = new TriggerEvent[Enum.GetValues(typeof(TriggerID)).Length];

            public static void ResetPlayerTrigger()
            {
                PlayerTrigger = new TriggerEvent[Enum.GetValues(typeof(TriggerID)).Length];
            }
            public static void CallOnPlayerTrigger(TriggerID id, CreatureController creature)
            {
                PlayerTrigger[(int)id].Invoke(creature);
            }
            
            public static void AddPlyerTrigger(TriggerID id, TriggerEvent action)
            {
                PlayerTrigger[(int)id] += action;
                
            }

            public static void RemovePlayerTrigger(TriggerID id, TriggerEvent action)
            {
                PlayerTrigger[(int)id] -= action;
            }

            public static List<TriggerEvent[]> EnemyTrigger = new List<TriggerEvent[]>();

            public static void ResetEnemyTrigger()
            {
                EnemyTrigger = new List<TriggerEvent[]>();
            }

            public static void CallOnEnemyTrigger(int index, TriggerID id, CreatureController creature) // ȣ��
            {
                EnemyTrigger[index][(int)id].Invoke(creature);
            }
            public static int AddEnemy() //���� ���� ���, ���� ������ �� ȣ���ؾ��ϴ� ��
            {
                int index = EnemyTrigger.Count;
                EnemyTrigger.Insert(index, new TriggerEvent[Enum.GetValues(typeof(TriggerID)).Length]);
                return index;
            }
            public static void RemoveEnemy(int index)
            {
                if (0 <= index && index < EnemyTrigger.Count)
                {
                    EnemyTrigger[index] = null;
                }
            }

            public static void AddEnemyTrigger(int index, TriggerID id, TriggerEvent action)
            {
                EnemyTrigger[index][(int)id] += action;
            }

            public static void RemoveEnemyTrigger(int index, TriggerID id, TriggerEvent action)
            {
                EnemyTrigger[index][(int)id] -= action;
            }
        }
    }
    
}





