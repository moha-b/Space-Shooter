using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _topEnemy;
    [SerializeField] GameObject _topEnemyContainer;
    [SerializeField] GameObject _bottomEnemy;
    [SerializeField] GameObject _bottomEnemyContainer;
    [SerializeField] GameObject _leftEnemy;
    [SerializeField] GameObject _leftEnemyContainer;
    [SerializeField] GameObject _rightEnemy;
    [SerializeField] GameObject _rightEnemyContainer;
    bool _isSpawned = true;
    float _topSpawnTime = 1f;
    float _bottomSpawnTime = 2f;
    float _leftSpawnTime = 1f;
    float _rightSpawnTime = 1f;


    void Start()
    {
        StartCoroutine(spawningFromTheTop());
        StartCoroutine(spawningFromTheBottom());
        StartCoroutine(spawningFromTheLeft());
        StartCoroutine(spawningFromTheRight());
    }

    IEnumerator spawningFromTheTop()
    {
        while (_isSpawned)
        {
            Vector3 spawning = new Vector3(Random.Range(-7f, 7f), 7f, 0f);
            GameObject newEnemy = Instantiate(_topEnemy, spawning, Quaternion.identity);
            newEnemy.transform.parent = _topEnemyContainer.transform;
            yield return new WaitForSeconds(_topSpawnTime);
        }
    }
    IEnumerator spawningFromTheBottom()
    {
        while (_isSpawned)
        {
            Vector3 spawning = new Vector3(Random.Range(-7f, 7f), -7f, 0f);
            GameObject newEnemy = Instantiate(_bottomEnemy, spawning, Quaternion.identity);
            newEnemy.transform.parent = _bottomEnemyContainer.transform;
            yield return new WaitForSeconds(_bottomSpawnTime);
        }
    }

    IEnumerator spawningFromTheLeft()
    {
        while (_isSpawned)
        {
            Vector3 spawning = new Vector3(Random.Range(-13f, -10f), Random.Range(-4, 4), 0f);
            GameObject newEnemy = Instantiate(_leftEnemy, spawning, Quaternion.identity);
            newEnemy.transform.parent = _leftEnemyContainer.transform;
            yield return new WaitForSeconds(_leftSpawnTime);
        }
    }

    IEnumerator spawningFromTheRight()
    {
        while (_isSpawned)
        {
            Vector3 spawning = new Vector3(Random.Range(10f, 13f), Random.Range(-4,4), 0f);
            GameObject newEnemy = Instantiate(_rightEnemy, spawning, Quaternion.identity);
            newEnemy.transform.parent = _rightEnemyContainer.transform;
            yield return new WaitForSeconds(_rightSpawnTime);
        }
    }

    public void onPlayerDeath()
    {
        _isSpawned = false;
    }
}
