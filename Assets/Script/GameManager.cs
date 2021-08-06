using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDistance;
    public float gameTimer;
    public Text gameText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnEnemy();

        }
    }

    private void SpawnEnemy()
    {
        float randomAngle = Random.Range(0, Mathf.PI * 2.0f);
        GameObject enemyObject = Instantiate(enemyPrefab);
        enemyObject.transform.SetParent(this.transform);
        enemyObject.transform.position = new Vector3(Mathf.Cos(randomAngle) * spawnDistance, 1 + 1, Mathf.Sin(randomAngle) * spawnDistance);

        EnemyController enemyController = enemyObject.GetComponent<EnemyController>();
        enemyController.onEnemyDestroyed = () =>
          {
              OnEnemyDestroyed();
          };
    }

    public void OnEnemyDestroyed()
    {
        Debug.Log("enemy destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        gameText.text = "Time:" + Mathf.Floor(gameTimer);
        gameTimer -= Time.deltaTime;
        if(gameTimer<=0)
        {
            gameTimer = 0;
            gameText.text = "Game Over";
        }
    }
}
