using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCommand : MonoBehaviour
{
    public GameObject prefObj;

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
