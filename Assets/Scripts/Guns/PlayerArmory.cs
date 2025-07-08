using UnityEngine;

public class PlayerArmory : MonoBehaviour
{

    public Gun[] Guns;
    public int CurrentGunIndex;
    void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        // передаем Index текущего оружия
        CurrentGunIndex = gunIndex;
        for (int i = 0; i < Guns.Length; i++)
        {
            // если i будет ровно идексу пушки которую хотим взять то 
            if (i == gunIndex)
            {
                // то ее SetActive true
                Guns[i].Activate();
            }
            else
            {
                Guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        Guns[gunIndex].AddBullets(numberOfBullets);
    }
}
