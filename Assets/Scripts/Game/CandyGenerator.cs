using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyGenerator : MonoBehaviour
{
    public static CandyGenerator instance;
    public List<GameObject> candyPrefabs = new List<GameObject>();
    public float candySpeed = 2f;
    private float timeToCreate = 1.5f;
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
            CreateCandy();
            actualTime = 0f;
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    void CreateCandy()
    {
        GameObject candyPrefab = candyPrefabs[Random.Range(0, candyPrefabs.Count)];
        GameObject candy = Instantiate(candyPrefab, new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
        Rigidbody2D candyRB = candy.GetComponent<Rigidbody2D>();
        if (candyRB != null)
        {
            candyRB.velocity = new Vector2(-candySpeed, 0);
        }
        else
        {
            Debug.LogError("El caramelo no tiene Rigidbody2D.");
        }
    }

    public void ManageCandy(CandyController candyScript, PlayerMovement playerScript = null)
    {
    }
}