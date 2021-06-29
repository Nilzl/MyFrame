using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//命令模式示例，使用命令模式创建游戏对象
public class testCommand : MonoBehaviour
{
    private GameObject prefObj;
    private GameObject curObj;

    private void Start()
    {
        prefObj = Resources.Load<GameObject>("SpriteTest");
        GameObject.Find("add").GetComponent<Button>().onClick.AddListener(AddButtonEvent);
        GameObject.Find("undo").GetComponent<Button>().onClick.AddListener(undoButtonEvent);
        GameObject.Find("redo").GetComponent<Button>().onClick.AddListener(redoButtonEvent);
    }

    public void AddButtonEvent()
    {
        Command add = new AddCommand(prefObj);
        add.excute();
    }

    public void undoButtonEvent()
    {
        Command.curCommand.undo();
    }

    public void redoButtonEvent()
    {
        Command.curCommand.redo();
    }
}
