using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy;
    [SerializeField]
    GameObject _enemyContainer;
    bool _isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnRoutine()
    {
        while (_isDead == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8,8),7f,0f);
            GameObject enemy = Instantiate(_enemy,spawnPos,Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    public void playerDeath()
    {
        _isDead = true;
    }

}
