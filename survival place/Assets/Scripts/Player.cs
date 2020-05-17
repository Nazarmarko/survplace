using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public static Player Instance;

    public int health = 5;
    public int experience = 40;
    public int gold = 1000;

    public GameObject playerObj;
    public Text healthText;
    public Text expText;
    public Text goldText;

    public Quest quest; //can be transformed into list


    private void Awake()
    {
      
            Instance = this;
      
    }
    public void GoBattle() 
    {
        health -= 1;
        experience += 2;
        gold += 10;

        if (quest.IsActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                experience += quest.experienceReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }

    }

    public void Update()
    {
        //healthText.text = health.ToString();
        expText.text = experience.ToString();
        goldText.text = gold.ToString();
    }
}
