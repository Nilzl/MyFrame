using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 传统的观察者模式
/// </summary>
//将观察者定义为一个类
class Observer
{
    //接收到被观察者的通知
    public virtual void onNotify(GameObject obj,Event e)  {}
}

//被观察者
class Subject
{
    //需要被通知的观察者列表
    private List<Observer> observers = new List<Observer>();

    public void addObservser(Observer observer)
    {
        observers.Add(observer);
    }

    public void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    //发出通知
    public void Notify(GameObject obj,Event e)
    {
        foreach(Observer observer in observers)
        {
            observer.onNotify(obj, e);
        }
    } 


}

