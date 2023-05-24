using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{

    //https://www.youtube.com/watch?v=aUi9aijvpgs&t=391s
    [Header("File Storage Config")]
    [SerializeField] private string fileName = "save.game";
public static DataPersistenceManager instance { get; private set; }

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();
        
        //if no data can be loaded, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initialzing data to defaults.");
            NewGame();
        }
        //push the Loaded data to all other scripts that need it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
       
        //Debug.Log("Loaded death count = " + gameData.totalDeathAmount);
    }

    public void SaveGame()
    {
        //pass the data to other scripts so they can update it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        
       // Debug.Log("Saved death count = " + gameData.totalDeathAmount);

        //save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    //public void OnNewGameClicked()
    //{
    //    DataPersistenceManager.instance.NewGame();
    //}
    //public void OnLoadGameClicked()
    //{
    //    DataPersistenceManager.instance.LoadGame();
    //}
    //public void OnSaveGameClicked()
    //{
    //    DataPersistenceManager.instance.SaveGame();
    //}
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
