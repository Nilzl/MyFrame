using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//命令队列

//命令基类
class Command
{
    public static List<Command> commands = new List<Command>(); //命令列表

    public Command curCommand;

    public Command()
    {
       
    }

    //命令执行
    public virtual void excute() {
        curCommand = this;
        commands.Add(curCommand);
        // 创建新命令时清楚当前命令后的缓存命令
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i] == curCommand)
            {
                for (int j = i + 1; j < commands.Count; j++)
                {
                    commands.RemoveAt(j);
                }
            }
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
                else
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
                if (i< commands.Count - 1)
                    curCommand = commands[i + 1];
                else
                    return;
            }
        }
        curCommand.excute();
    } 
}

class AddCommand : Command
{
    private GameObject curObj;

    public AddCommand(GameObject obj):base() {
        curObj = obj;
    }

    public override void excute()
    {
        base.excute();
        GameObject.Instantiate(curObj);
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

class MoveCommand : Command
{
    public MoveCommand(MoveCommand unit, int x, int y) : base()
    {
        
    }
}
