using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static void SaveGame(string currentScene, int dialogueIndex)
    {
        PlayerPrefs.SetString("CurrentScene", currentScene);
        PlayerPrefs.SetInt("DialogueIndex", dialogueIndex);
        PlayerPrefs.Save();
    }

    public static void LoadGame(out string currentScene, out int dialogueIndex)
    {
        currentScene = PlayerPrefs.GetString("CurrentScene", "Station");
        dialogueIndex = PlayerPrefs.GetInt("DialogueIndex", 0);
    }

    public static void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}