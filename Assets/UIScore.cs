using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    
    public static int HeroScore;
    public static int EnemyScore;

    public Text Enemy;
    public Text Hero;

    private void Start()
    {
        Enemy.text = EnemyScore.ToString();
        Hero.text = HeroScore.ToString();
    }
}
