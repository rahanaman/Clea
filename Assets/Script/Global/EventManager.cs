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
        public static class 전투EventManager
        {//함수 걸고 빼고 어디에 걸고 뺄지는 TriggerID로 탐색하고, 호출할 때도 TriggerID로 호출하자~

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

            public static void CallOnEnemyTrigger(int index, TriggerID id) // 호출
            {
                EnemyTrigger[index][(int)id].Invoke();
            }
            public static int AddEnemyTrigger() //적대 유닛 등록, 전투 시작할 때 호출해야하는 것
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





