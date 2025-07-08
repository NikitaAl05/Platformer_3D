using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Spawn;
    public void Creat()
    {
        Instantiate(Prefab, Spawn.position, Spawn.rotation);
    }
}
