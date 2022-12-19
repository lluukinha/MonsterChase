using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform leftPos, rightPos;
    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            var side = randomSide == 0 ? leftPos : rightPos;
            var speed = randomSide == 0 ? Random.Range(4, 10) : -Random.Range(4, 10);
            var localScale = randomSide == 0 ? spawnedMonster.transform.localScale : new Vector3(-1f, 1f, 1f);

            spawnedMonster.transform.position = side.position;
            spawnedMonster.GetComponent<Monster>().speed = speed;
            spawnedMonster.transform.localScale = localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
