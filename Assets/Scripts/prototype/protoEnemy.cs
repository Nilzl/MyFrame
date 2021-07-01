using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 应用原型模式，实现从一个敌人原型生成多种类型的敌人

//敌人基类
class Enemy
{
    public GameObject enemyObj;
    public float HP;
    public float Speed;
    public Enemy(string name,float hp,float speed)
    {
        enemyObj = Resources.Load<GameObject>(name);
        HP = hp;
        Speed = speed;
    }
}

class Ghost : Enemy
{
    public Ghost(string name, float hp, float speed) : base(name,hp,speed){
        
    }
}

class Wolf : Enemy
{
    public Wolf(string name, float hp, float speed) :base(name, hp, speed)
    {

    }
}

class Zombie : Enemy
{
    public Zombie(string name, float hp, float speed) :base(name, hp, speed)
    {

    }
}

class Spawn
{
    public float interval;
    public int totalNum;
    /// <summary>
    /// 生产敌人函数
    /// </summary>
    /// <param name="enemy">传入需要生产的敌人实例</param>
    /// <param name="i">生产敌人间隔</param>
    /// <param name="num">生产敌人的总数量</param>
    /// <returns></returns>
    public T spawnEnemy<T>(T enemy,float i,int num)
    {
        interval = i;
        totalNum = num;
        return enemy;
    }
}
