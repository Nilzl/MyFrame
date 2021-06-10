using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//命令队列

//命令基类
class Command
{
    public static List<Command> commands = new List<Command>(); //命令列表

    public static Command curCommand = null;//当前命令

    //记一下撤销到开始时候的标记
    private bool isBegin = false;

    public Command()
    {
       
    }

    //命令执行
    public virtual void excute() {
        bool isExist = false;

        //先判断当前执行的命令是否在命令列表内
        foreach(Command c in commands)
        {
            if (c == this)
            {
                isExist = true;
                curCommand = this;
            }    
        }

        if (!isExist)
        {
            // 创建新命令时先清除当前命令后的缓存命令
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] == curCommand)
                {
                    
                    //撤销到开始位置时直接清空命令列表
                    if (curCommand.isBegin)
                    {
                        commands.Clear();
                    }
                    int len = commands.Count - 1 - i;
                    while (len>0)
                    {
                        commands.RemoveAt(i + 1);
                        len--;
                    }
                    break;
                }
            }
            curCommand = this;
            commands.Add(curCommand);      
        }
        
    } 

    //命令撤销 ctr Z
    public virtual void undo() {

        for(int i = 0; i < commands.Count; i++)
        {
            if(commands[i] == curCommand)
            {
                if (i > 0)
                    curCommand = commands[i - 1];
                else if(i == 0) //撤销到开始位置时，curCommand仍然指向第一个元素，标记一下
                {
                    curCommand.isBegin = true;
                }
                return;
            }
        }
    }

    //命令重做 ctr Y
    public virtual void redo()
    {
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i] == curCommand)
            {
                //撤销到开始位置，重做直接执行当前元素的excute方法，下一次再往后推
                if (curCommand.isBegin)
                {
                    curCommand.excute();
                    curCommand.isBegin = false;
                }
                else if (i < commands.Count - 1)
                {
                    curCommand = commands[i + 1];
                    curCommand.excute();
                }
                return;
            }
        }
    } 
}

//增加游戏对象命令
class AddCommand : Command
{
    private GameObject prefObj;
    private GameObject curObj;

    public AddCommand(GameObject obj):base() {
        prefObj = obj;
    }

    public override void excute()
    {
        base.excute();
        curObj = GameObject.Instantiate(prefObj);
    }

    public override void undo()
    {
        base.undo();
        GameObject.Destroy(curObj);
    }

    public override void redo()
    {
        base.redo();
    }
}

//移动命令
class MoveCommand : Command
{
    public MoveCommand(MoveCommand unit, int x, int y) : base()
    {
        
    }
}
