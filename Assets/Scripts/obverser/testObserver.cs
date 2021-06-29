using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//观察者模式示例

//使用继承实现观察者模式
class obSample : Observer
{
    public override void onNotify(GameObject obj, Event e)
    {
        base.onNotify(obj, e);
        switch (e.type)
        {
            case EventType.KeyDown:
                Debug.Log("按键按下");
                break;
            case EventType.MouseDown:
                Debug.Log("鼠标按下");
                break;
        }     
    }
}



public class testObserver : MonoBehaviour
{
    obSample obS = new obSample();
    Subject subject = new Subject();

    //使用委托实现观察者模式
    private delegate void observerKeyHandler(GameObject obj, Event e);//委托原型（函数指针） 无返回的delega可以使用Action 有返回的delegate使用Func
    private observerKeyHandler observerKey;
    private event observerKeyHandler observerKeyEvent;//事件是一种特殊的委托，只能+=，-=，不能直接用=

    private void onNotify(GameObject obj, Event e)
    {
        switch (e.type)
        {
            case EventType.KeyDown:
                Debug.Log("按键按下");
                break;
            case EventType.MouseDown:
                Debug.Log("鼠标按下");
                break;
        }
    }

    private void Start()
    {
        subject.addObservser(obS);
        observerKeyEvent += onNotify;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Event e = new Event
            {
                type = EventType.KeyDown
            };
            //subject.Notify(gameObject,e);
            observerKeyEvent(gameObject, e);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Event e = new Event
            {
                type = EventType.MouseDown
            };
            //subject.Notify(gameObject, e);
            observerKeyEvent(gameObject, e);
        }   
    }
}
