using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

[System.Serializable]
public class SaveData
{
    public int winSave;
    public int loseSave;
}
public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject[] menu;
    private TMP_Text[] textStatistic = new TMP_Text[2];
    private int winValue;
    private int loseValue;

    private string saveFilePath;
    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/save.dat";
        LoadData();
        EnemyController.winStatistic += WinGame;
        PlayerGetDamage.loseStatistic += LoseGame;
        for (int i = 0; i <= textStatistic.Length - 1; i++)
        {
            textStatistic[i] = menu[i].GetComponentInChildren<TMP_Text>(includeInactive: true);
        }

    }
    private void WinGame()
    {
        Time.timeScale = 0;
        winValue += 1;

        SaveData data = new SaveData();
        data.winSave = winValue;
        data.loseSave = loseValue;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(saveFilePath);

        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();

        textStatistic[1].text = "Побед " + winValue + " " + "Поражений " + loseValue;
        if (menu[1] != null) menu[1].SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void LoseGame()
    {
        Time.timeScale = 0;
        loseValue += 1;

        SaveData data = new SaveData();
        data.winSave = winValue;
        data.loseSave = loseValue;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(saveFilePath);

        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();

        textStatistic[0].text = "Побед " + winValue + " " + "Поражений " + loseValue;
        if (menu[0] != null) menu[0].SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(saveFilePath, FileMode.Open);

            SaveData data = (SaveData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            winValue = data.winSave;
            loseValue = data.loseSave;
        }
        else
        {
            winValue = 0;
            loseValue = 0;
        }
    }
}
