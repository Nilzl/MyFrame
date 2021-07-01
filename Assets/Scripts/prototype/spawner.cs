using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    Spawn spawn = new Spawn();
    Enemy ghost, zombie, wolf;
    void Start()
    {
        ghost = spawn.spawnEnemy<Ghost>(new Ghost("Ghost", 100.0f, 2.5f), 10, 5);
        StartCoroutine("spawnGhost");
    }

    IEnumerator spawnGhost()
    {
        int ghostNum = 0;
        while (ghostNum < spawn.totalNum)
        {
            GameObject.Instantiate(ghost.enemyObj,transform);
            ghostNum++;
            yield return new WaitForSeconds(spawn.interval);
        }
        yield break;
    }
}
