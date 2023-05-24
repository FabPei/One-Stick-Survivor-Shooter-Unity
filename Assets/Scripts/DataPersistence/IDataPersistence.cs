using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data); //no ref: implementing script can only READ

    void SaveData(ref GameData data); //ref: implementing script can READ and WRITE
}
