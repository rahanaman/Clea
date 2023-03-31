using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace Event
{
    namespace 전투
    {
        public delegate void TEvent<T>(T t);
        public delegate void TriggerEvent (CreatureController t);
        public static class 전투EventManager
        {//함수 걸고 빼고 어디에 걸고 뺄지는 TriggerID로 탐색하고, 호출할 때도 TriggerID로 호출하자~

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

            public static void CallOnEnemyTrigger(int index, TriggerID id, CreatureController creature) // 호출
            {
                EnemyTrigger[index][(int)id].Invoke(creature);
            }
            public static int AddEnemy() //적대 유닛 등록, 전투 시작할 때 호출해야하는 것
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





