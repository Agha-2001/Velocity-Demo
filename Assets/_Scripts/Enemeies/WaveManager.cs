using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField] int StartingValue;
    [SerializeField] int IncrementRate;
    [SerializeField] int FinalValue;
    [SerializeField] float StartDelay;

    [SerializeField] TextMeshProUGUI WaveText;

    EnemySpawnSystem spawnSystem;
    int currentValue;
    bool isWaveInProgress;
    int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        currentValue = StartingValue;
        spawnSystem = EnemySpawnSystem.GetInstance();
        isWaveInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaveInProgress && spawnSystem.GetActiveEnemiesCount() == 0)
        {


            if (currentValue <= FinalValue)
            {
                currentValue += IncrementRate;
            }

            StartCoroutine(StartWave());
        }
    }

    IEnumerator StartWave()
    {
        isWaveInProgress = true;
        waveNumber++;
        WaveText.text = waveNumber.ToString();
        yield return new WaitForSeconds(StartDelay);
        spawnSystem.SpawnEnemies(currentValue);
        isWaveInProgress = false;
    }
}
