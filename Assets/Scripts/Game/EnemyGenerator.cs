using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public float enemySpeed = 2f;
    private float timeToCreate = 1f;
    private float actualTime = 0f;
    private float limitSuperior;
    private float limitInferior;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        SetMinMax();
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (timeToCreate <= actualTime)
        {
            CreateEnemy();
            actualTime = 0f;
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    void CreateEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
        Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
        if (enemyRB != null)
        {
            enemyRB.velocity = new Vector2(-enemySpeed, 0);
        }
        else
        {
            Debug.LogError("El enemigo no tiene Rigidbody2D.");
        }
    }
}
