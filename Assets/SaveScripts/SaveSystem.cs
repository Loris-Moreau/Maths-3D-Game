using Newtonsoft.Json.Linq;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    /*public GameObject loadingScreen;
    public Image progressBar;
    public TextMeshProUGUI progressText;*/

    public GameObject player;

    public int _lvl;

    public Vector3 position;

    public GameObject enemyGroup;
    private List<GameObject> enemies;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public void Save(int scene)
    {
        _lvl = scene;
        position = player.transform.position;

        string saveFilePath = Application.persistentDataPath + "/save.fsav";
        //print("Saving to : " + saveFilePath);

        JObject jObject = new JObject
        {
            { "Component Name", GetType().ToString() }
        };

        JObject jDataObject = new JObject();
        jObject.Add("Data", jDataObject);

        jDataObject.Add("Level", _lvl);

        StreamWriter sw = new StreamWriter(saveFilePath);
        sw.WriteLine(jObject.ToString());

        sw.Close();
    }
    public void Load()
    {
        //StartCoroutine(LoadingScreen());

        string saveFilePath = Application.persistentDataPath + "/save.fsav";

        StreamReader sr = new StreamReader(saveFilePath);
        string jsonString = sr.ReadToEnd();

        sr.Close();
        JObject jObject = JObject.Parse(jsonString);

        _lvl = (int)jObject["Data"]["Level"];
    }

    /*private IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync("Game Scene");

		while (!async.isDone)
        {
            progressBar.fillAmount = async.progress;

			if (async.progress >= 0.95f)
			{
                progressText.text = "Press any key to continue";
            }
            yield return null;
        }
        loadingScreen.SetActive(false);
    }*/

    public void getEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {



        }
    }

    public void getEnemyCount()
    {

    }

    public Vector3 getEnemyPosition(int i)
    {
        return enemyGroup.transform.GetChild(i).position;
    }
}
