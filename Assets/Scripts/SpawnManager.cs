using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _enemyContainer;
    bool _isSpawned = true;

    void Start()
    {
        StartCoroutine(spawnning());
    }

    IEnumerator spawnning()
    {
        while (_isSpawned)
        {
            Vector3 spawning = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            GameObject newEnemy = Instantiate(_enemy, spawning, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3f);
        }
    }
    public void onPlayerDeath()
    {
        _isSpawned = false;
    }
}
