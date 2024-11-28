using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interface : MonoBehaviour
{
    public GameSystem gameSystem;
    public float bricks;
    [SerializeField] public Text textBricks;
    [SerializeField] public Text textPlayer;
    [SerializeField] public Text textEnemy;

    void Start()
    {
        gameSystem.enemyCount = 0; gameSystem.playerCount = -1;
        bricks = 0;
    }
    public void Update()
    {
        textEnemy.text = "Враг: " + gameSystem.enemyCount;
        textPlayer.text = "Игрок: " + gameSystem.playerCount;
        textBricks.text = "Кирпичи: " + ((int)bricks);
        if (bricks <= 100) bricks += Time.deltaTime * 1f;
    }
}
