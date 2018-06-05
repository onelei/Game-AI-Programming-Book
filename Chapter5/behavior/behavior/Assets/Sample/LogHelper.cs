/********************************************************************************
** auth： Onelei
** date： 2018/1/1 16:51:40
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/

using System.Runtime.CompilerServices;
using UnityEngine;
using  UnityEngine.UI;

public class LogHelper : MonoBehaviour
{
    public Text Text_Log;

    void Awake()
    {
        Instance = this;
    }
    public static LogHelper Instance;

    public void Log(string message)
    {
        Text_Log.text = Text_Log.text +"\n"+ message;
    }
}
