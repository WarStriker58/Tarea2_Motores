using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGenerator : MonoBehaviour
{
    public static LifeGenerator instance;
    public List<GameObject> lifeItemPrefabs = new List<GameObject>();
    public float lifeItemSpeed = 2f;
    public float timeToCreate = 1.5f;
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
            CreateLifeItem();
            actualTime = 0f;
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    void CreateLifeItem()
    {
        GameObject lifeItemPrefab = lifeItemPrefabs[Random.Range(0, lifeItemPrefabs.Count)];
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f);
        GameObject lifeItem = Instantiate(lifeItemPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D lifeItemRB = lifeItem.GetComponent<Rigidbody2D>();
        if (lifeItemRB != null)
        {
            lifeItemRB.velocity = new Vector2(-lifeItemSpeed, 0);
        }
        else
        {
            Debug.LogError("El objeto que aumenta la vida no tiene Rigidbody2D.");
        }
    }
}