using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCommand : MonoBehaviour
{
    public GameObject prefObj;

    private Command command;

    private void Start()
    {
        prefObj = Resources.Load<GameObject>("SpriteTest");
    }

    public void AddButtonEvent()
    {
        Command command = new AddCommand(prefObj);
        command.excute();
    }

    public void undoButtonEvent()
    {

    }
}
