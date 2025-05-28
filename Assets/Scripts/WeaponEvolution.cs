using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponEvolution : MonoBehaviour
{
    [System.Serializable]
    public class WeaponData
    {
        public int ID;
        public string Name;
        public string Rare;
        public List<float> Levels;

        public WeaponData(int id, string name, string rare, List<float> levels)
        {
            ID = id;
            Name = name;
            Rare = rare;
            Levels = levels;
        }
    }

    public List<WeaponData> weaponList = new List<WeaponData>();
    public int currentWeaponIndex = 0;
    public int currentLevel = 1;
    public float currentExp = 0f;
    public float expPerLevel = 100f; // 예시: 레벨업에 100 경험치 필요





    void Start()
    {
        LoadCSV();
        PrintCurrentWeapon();
    }

    void Update()
    {

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame || Input.GetMouseButtonDown(0) )
        {
            GainExp(10f);
        }


    }

    public void GainExp(float amount)
    {
        currentExp += amount;

        while (currentExp >= expPerLevel)
        {
            currentExp -= expPerLevel;
            currentLevel++;
            expPerLevel += 10f;

            Debug.Log($"레벨업! 현재 레벨: {currentLevel}");

            if (currentLevel > 10)
            {
                EvolveWeapon();
            }
        }

        PrintCurrentWeapon();
    }

    public void EvolveWeapon()
    {
        if (currentWeaponIndex + 1 < weaponList.Count)
        {
            currentWeaponIndex++;
            currentLevel = 1;
            currentExp = 0;
            
            Debug.Log($"무기 진화! 새로운 무기: {weaponList[currentWeaponIndex].Name}");
        }
        else
        {
            currentLevel = 10;
            currentExp = 0;
            expPerLevel = 0f;
            Debug.Log("최종 무기입니다. 더 이상 진화할 수 없습니다.");
        }
    }

    public void PrintCurrentWeapon()
    {
        var weapon = weaponList[currentWeaponIndex];
        float attackPower = weapon.Levels[Mathf.Clamp(currentLevel - 1, 0, weapon.Levels.Count - 1)];
        Debug.Log($"무기: {weapon.Name}, 등급: {weapon.Rare}, 레벨: {currentLevel}, 공격력: {attackPower}, 경험치: {currentExp}/{expPerLevel}");
    }
    public float Damage()
    {
        var weapon = weaponList[currentWeaponIndex];
        return weapon.Levels[Mathf.Clamp(currentLevel - 1, 0, weapon.Levels.Count - 1)];
    }

    public string RareText()
    {
        var weapon = weaponList[currentWeaponIndex];
        return weapon.Rare;
    }




    public string WeaponName()
    {
        var weapon = weaponList[currentWeaponIndex];
        return weapon.Name;
    }

    



    void LoadCSV()
    {
        TextAsset csvData = Resources.Load<TextAsset>("Data_Table_Knife");
        if (csvData == null)
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다.");
            return;
        }

        StringReader reader = new StringReader(csvData.text);
        bool isFirstLine = true;

        while (true)
        {
            string line = reader.ReadLine();
            if (line == null) break;

            if (isFirstLine)
            {
                isFirstLine = false;
                continue;
            }

            string[] values = line.Split(',');

            if (values.Length < 4) continue;

            int id = int.Parse(values[0]);
            string name = values[1];
            string rare = values[2];

            List<float> levels = new List<float>();
            for (int i = 3; i < values.Length; i++)
            {
                if (float.TryParse(values[i], out float val))
                    levels.Add(val);
                else
                    levels.Add(0f);
            }

            weaponList.Add(new WeaponData(id, name, rare, levels));
        }

        Debug.Log("무기 데이터 로딩 완료");
    }
}
