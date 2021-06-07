using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//命令示例

//命令基类
class Command
{
    public static Queue<Command> units; //命令队列

    public Command(Command unit)
    {
        units.Enqueue(unit);
    }

    public virtual void excute(GameObject obj){} //命令执行
    public virtual void undo() { } //命令撤销 ctr Z
    public virtual void redo() { } //命令重做 ctr Y
}

class AddComand : Command
{
    public AddComand(AddComand unit):base(unit) {}

    public override void excute(GameObject obj)
    {
        base.excute(obj);
        GameObject.Instantiate(obj);
    }

    public override void undo()
    {
        base.undo();
    }
}
