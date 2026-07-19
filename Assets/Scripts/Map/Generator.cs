using Unity.AI.Navigation;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject Item1;
    [SerializeField] GameObject Item2;
    [SerializeField] GameObject Item3;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;

    private NavMeshPlus.Components.NavMeshSurface navMeshSurface;
    private float nextTick;
    private int dice;
    private GameObject[] allSpawnpoints;

    void Start()
    {
        allSpawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        navMeshSurface = GetComponent<NavMeshPlus.Components.NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        //Instantiate(Enemy, transform.position, Quaternion.identity);
        DiceRoll();
        Invoke("SpawnWaveStart", 14);
        Invoke("SpawnWave", 14 + 39);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetAxis("Debug1") > 0 && Time.time >= nextTick)
        {
            Instantiate(Enemy1, transform.position, Quaternion.identity);
            nextTick = Time.time + 0.5f;
        }
        if (Input.GetAxis("Debug2") > 0 && Time.time >= nextTick)
        {
            Instantiate(Enemy2, transform.position, Quaternion.identity);
            nextTick = Time.time + 0.5f;
        }
        if (Input.GetAxis("Debug3") > 0 && Time.time >= nextTick)
        {
            Instantiate(Enemy3, transform.position, Quaternion.identity);
            nextTick = Time.time + 0.5f;
        }
        if (Input.GetAxis("Debug4") > 0 && Time.time >= nextTick)
        {
            Instantiate(Enemy4, transform.position, Quaternion.identity);
            nextTick = Time.time + 0.1f;
        }
        */
    }

    private void DiceRoll()
    {
        switch (Random.Range(0, 7)) 
        { 
            case 0:
                Instantiate(Item1, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(Item2, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Item3, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Enemy1, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Enemy2, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Enemy3, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(Enemy4, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                break;
            default: break;
        }
        PlayerMainScript.Game_player.score += 20;
        Invoke("DiceRoll", Random.Range(0, 4));
    }
    private void SpawnWaveStart()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (Random.Range(3, 7))
            {
                case 3:
                    Instantiate(Enemy1, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Enemy2, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Enemy3, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Enemy4, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                default: break;
            }
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < 10; i++)
        {
            switch (Random.Range(3, 7))
            {
                case 3:
                    Instantiate(Enemy1, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Enemy2, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Enemy3, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Enemy4, allSpawnpoints[Random.Range(0, allSpawnpoints.Length)].transform.position, Quaternion.identity);
                    break;
                default: break;
            }
        }
        Invoke("SpawnWave", 73);
    }
}
