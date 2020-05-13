using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject enemy;
    public GameObject target;
    private int timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            enemy.GetComponent<EnemyMovement>().target = target;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Representation of how much time until a new enemy should spawn
        if(timePassed > 150 && enemies.Count < 2)
        {
            AddEnemy();
            timePassed = 0;
        }

        timePassed++;
    }

    private void AddEnemy()
    {
        enemies.Add(Instantiate(enemy, this.transform));
    }
}
