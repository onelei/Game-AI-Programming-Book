using System;
using lemon_bt_CShape;
public class Bt_Debug
{
    public static void Debug(Bt_Result _result,string msg)
    {
        switch (_result)
        {
            case Bt_Result.FAIL:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case Bt_Result.RUNING:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case Bt_Result.SUCCESSFUL:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

