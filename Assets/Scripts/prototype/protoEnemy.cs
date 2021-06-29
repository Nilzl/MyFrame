using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 应用原型模式，实现从一个敌人原型生成多种类型的敌人

//敌人基类
class Enemy
{
    public GameObject enemyObj;
    public Enemy(string name)
    {
        enemyObj = Resources.Load<GameObject>(name);
    }
}

class Mace : Enemy
{
    public Mace(string name) : base(name){
        
    }
}