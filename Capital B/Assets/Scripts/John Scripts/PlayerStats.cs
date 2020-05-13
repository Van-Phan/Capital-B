using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const float MAX_HEALTH = 10;
    public float currHealth;
    public float attackStat;
    public float defenseStat;
    public float speedStat;
    public float magicStat;
    public float mana;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            currHealth--;
        }

        if(currHealth <= 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
