
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoadSpawner : MonoBehaviour
{
    [SerializeField]
    List<Level> levelBasics;
    private LevelDificulty _currentDificulty;
    private List<GameObject> _activeTiles = new List<GameObject>();
    private float
        _groundLength = 10f,
        _spawnTriggerDistance = 50f,
        nextSpawnTriggerX;
    Vector3 nextInstantiatePosition = Vector3.zero;
    private int _startingTiles = 5;
    private int _maxRoadCount = 20;

    private void Awake()
    {
        _currentDificulty = LevelDificulty.AClass;
        for (int i = 0; i < _startingTiles; i++)
            Spawn();
    }
    
    private void Update()
    {
        if (GameController.Instance.Player.PositionZ() > nextSpawnTriggerX)
        {
            DeleteTiles();
            Spawn();
            ChangeDifficulty();
        }
    }
    
    private void Spawn()
    {
        InstantiateNewLevelDependOnDifficulty();
        CalculateNextSpawnPosition();
    }

    private void InstantiateNewLevelDependOnDifficulty()
    {
        if (_currentDificulty != LevelDificulty.All)
        {
            List<Level> selectedLevels = new List<Level>();
            foreach (Level lvl in levelBasics)
            {
                if (lvl.Dificulty == _currentDificulty)
                    selectedLevels.Add(lvl);
            }
            int number = Random.Range(0, selectedLevels.Count);
            GameObject level = Instantiate(selectedLevels[number].gameObject, nextInstantiatePosition, Quaternion.identity);
            _activeTiles.Add(level);
        }
        else
        {
            int number = Random.Range(0, levelBasics.Count);
            GameObject level = Instantiate(levelBasics[number].gameObject, nextInstantiatePosition, Quaternion.identity);
            _activeTiles.Add(level.gameObject);
        }
    }

    private void CalculateNextSpawnPosition()
    {
        nextInstantiatePosition += Vector3.forward * _groundLength;
        nextSpawnTriggerX = nextInstantiatePosition.z - _spawnTriggerDistance;
    }

    private void ChangeDifficulty()
    {
        switch (_currentDificulty)
        {
            case LevelDificulty.AClass:
                _currentDificulty = LevelDificulty.BClass;
                break;

            case LevelDificulty.BClass:
                _currentDificulty = LevelDificulty.CClass;
                break;

            case LevelDificulty.CClass:
                _currentDificulty = LevelDificulty.All;
                break;
        }
    }

    private void DeleteTiles()
    {
        if (_activeTiles.Count > _maxRoadCount)
        {
            Destroy(_activeTiles[0]);
            _activeTiles.RemoveAt(0);
            
        }

    }

}