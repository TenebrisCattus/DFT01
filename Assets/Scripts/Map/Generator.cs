using Unity.AI.Navigation;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;

    private NavMeshPlus.Components.NavMeshSurface navMeshSurface;
    private float nextTick;

    void Start()
    {
        navMeshSurface = GetComponent<NavMeshPlus.Components.NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        //Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
