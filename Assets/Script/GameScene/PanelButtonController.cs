using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonController : MonoBehaviour
{
    public void OnClick(Transform canvas, PanelID id)
    {
        Instantiate(Data.Database.Panel[(int)id], canvas);
    }
}
