/*
 * test the lemon-bt-CShape;
 * 
 */

using System;
using lemon_bt_CShape;

class Test
{
    static void Main(string[] args)
    {

        // test Bt_Sequence;
        testBt_Sequence();

        // test Bt_Select;
        testBt_Select();

        // test Bt_ParallelSelector;
        testBt_ParallelSelector();

        // test Bt_ParallelSequence;
        testBt_ParallelSequence();

        //test Bt_Decorator;
        testBt_Decorator();

        Console.ReadLine();
    }

    #region test Bt_Sequence
    static void testBt_Sequence()
    {
        Console.WriteLine("test Bt_Sequence=>");
        Bt_Sequence seq = new Bt_Sequence();
        TestNodeFail _test1 = new TestNodeFail();
        TestNodeSuccess _test2 = new TestNodeSuccess();
        TestNodeRuning _test3 = new TestNodeRuning();
        seq.addChild(_test1);
        seq.addChild(_test2);
        seq.addChild(_test3);

        Bt_Result result = seq.doAction();
        Console.WriteLine("test testBt_Sequence result =>" + result);
    }
    #endregion;

    #region test Bt_Select
    static void testBt_Select()
    {
        Console.WriteLine("test Bt_Select=>");
        Bt_Select sel = new Bt_Select();
        TestNodeFail _test1 = new TestNodeFail();
        TestNodeSuccess _test2 = new TestNodeSuccess();
        TestNodeRuning _test3 = new TestNodeRuning();
        sel.addChild(_test1);
        sel.addChild(_test2);
        sel.addChild(_test3);

        Bt_Result result = sel.doAction();
        Console.WriteLine("test testBt_Select result =>" + result);
    }
    #endregion;

    #region test Bt_ParallelSelector
    static void testBt_ParallelSelector()
    {
        Console.WriteLine("test Bt_ParallelSelector=>");
        Bt_ParallelSelector pasel = new Bt_ParallelSelector();
        TestNodeFail _test1 = new TestNodeFail();
        TestNodeSuccess _test2 = new TestNodeSuccess();
        TestNodeRuning _test3 = new TestNodeRuning();

        pasel.addChild(_test1);
        pasel.addChild(_test2);
        pasel.addChild(_test3);

        Bt_Result result = pasel.doAction();
        Console.WriteLine("test testBt_ParallelSelector result =>" + result);
    }
    #endregion;

    #region test Bt_ParallelSequence
    static void testBt_ParallelSequence()
    {
        Console.WriteLine("test Bt_ParallelSequence=>");
        Bt_ParallelSequence paseq = new Bt_ParallelSequence();
        TestNodeFail _test1 = new TestNodeFail();
        TestNodeSuccess _test2 = new TestNodeSuccess();
        TestNodeRuning _test3 = new TestNodeRuning();

        paseq.addChild(_test1);
        paseq.addChild(_test2);
        paseq.addChild(_test3);

        Bt_Result result = paseq.doAction();
        Console.WriteLine("test Bt_ParallelSequence result =>" + result);
    }
    #endregion;

    #region test Bt_Decorator
    static void testBt_Decorator()
    {
        Console.WriteLine("test Bt_Decorator=>");
        Bt_Decorator pasel = new Bt_Decorator();
        TestNodeFail _test1 = new TestNodeFail();
        TestNodeSuccess _test2 = new TestNodeSuccess();
        TestNodeRuning _test3 = new TestNodeRuning();

        
        Bt_Result result = pasel.doAction();
        Console.WriteLine("test Bt_Decorator result =>" + result);

    }
    #endregion;
}

