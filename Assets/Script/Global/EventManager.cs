using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public delegate int VoidEvent(int data);
public delegate void TEvent<T>(T t);
public static class EventManager
{

    public static List<VoidEvent> PlayerTrigger = new List<VoidEvent>(System.Enum.GetValues(typeof(TriggerID)).Length);

    public static int CallOnPlayerTrigger(TriggerID id, int data)
    {
        if (PlayerTrigger[(int)id] == null) return data;
        else
        {
            return PlayerTrigger[(int)id].Invoke(data);
        }
        
    }

    public static Dictionary<CreatureController,List<VoidEvent>> EnemyTrigger = new Dictionary<CreatureController,List<VoidEvent>>();

    public static int CallOnEnemyTrigger(CreatureController enemy, TriggerID id, int data) // 호출
    {
        if (EnemyTrigger[enemy][(int)id] == null) return data;
        else
        {
            return EnemyTrigger[enemy][(int)id].Invoke(data);
        }
        
    }
    public static void AddEnemyTrigger(CreatureController enemy) //적대 유닛 등록, 전투 시작할 때 호출해야하는 것
    {
        EnemyTrigger.Add(enemy, new List<VoidEvent>(System.Enum.GetValues(typeof(TriggerID)).Length));
    }

    public static void RemoveEnemyTrigger(CreatureController enemy)
    {
        EnemyTrigger.Remove(enemy);
    }

    public static TEvent<CardController> OnClickCard;
    public static TEvent<CardController> OnMouseOverCard;
    public static TEvent<CreatureController> OnClickEnemy;
    public static TEvent<CreatureController> OnMouseOverEnemy;

    public static void CallOnClickCard(CardController card)
    {
        OnClickCard?.Invoke(card);
    }

    public static void CallOnMouseOverCard(CardController card)
    {
        OnMouseOverCard?.Invoke(card);
    }

    public static void CallOnClickEnemy(CreatureController cr)
    {
        OnClickEnemy?.Invoke(cr);
    }











}





/*
    

*/