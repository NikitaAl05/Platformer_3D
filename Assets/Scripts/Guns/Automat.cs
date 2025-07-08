using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    // [Space(12)]
    [Header("Automat")]
    public int NumberOfBullets;     // NumberOfBullets -= 1;
    public TMP_Text BulletsText;
    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        // base - значит что мы коипируем у родительского скрипта Gun метод Shot
        base.Shot();
        NumberOfBullets -= 1;
        UpdateText();

        if (NumberOfBullets == 0)
            PlayerArmory.TakeGunByIndex(0);
    }

    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    void UpdateText()
    {
        BulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}

