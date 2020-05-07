using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TableController : MonoBehaviour
{
    public GameObject valueLabelData;
    public GameObject horizontalTitleLabelData;
    public JsonChallenge jsonChallengeClass = new JsonChallenge();
    public ScrollRect scrollRect;

    
    void Start()
    {
        string _jsonPath = $"{Application.streamingAssetsPath}/JsonChallenge.json";
        string _json = File.ReadAllText(_jsonPath, Encoding.UTF8);
        Debug.Log(_json);
        jsonChallengeClass = JsonUtility.FromJson<JsonChallenge>(_json);


        //Title label
        GameObject horizontalTitle = Instantiate(horizontalTitleLabelData, scrollRect.content.transform);
        for (int i = 0; i < jsonChallengeClass.ColumnHeaders.Length; i++)
        {
            DataValueController dataValueController = Instantiate(valueLabelData, horizontalTitle.transform).GetComponent<DataValueController>();
            dataValueController.Configure(jsonChallengeClass.ColumnHeaders[i]);
        }
        horizontalTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(360 * jsonChallengeClass.ColumnHeaders.Length, 100);

        //Data labels
        for (int i = 0; i < jsonChallengeClass.Data.Length; i++)
        {
            GameObject horizontalData = Instantiate(horizontalTitleLabelData, scrollRect.content.transform);
            Instantiate(valueLabelData, horizontalData.transform).GetComponent<DataValueController>().Configure(jsonChallengeClass.Data[i].ID);
            Instantiate(valueLabelData, horizontalData.transform).GetComponent<DataValueController>().Configure(jsonChallengeClass.Data[i].Name);
            Instantiate(valueLabelData, horizontalData.transform).GetComponent<DataValueController>().Configure(jsonChallengeClass.Data[i].Role);
            Instantiate(valueLabelData, horizontalData.transform).GetComponent<DataValueController>().Configure(jsonChallengeClass.Data[i].Nickname);
            horizontalData.GetComponent<RectTransform>().sizeDelta = new Vector2(360 * 4, 100);
        }
    }

}
[Serializable]
public class JsonChallenge
{
    public string Title;
    public string[] ColumnHeaders;
    public Datum[] Data;
}
[Serializable]
public class Datum
{
    public string ID;
    public string Name;
    public string Role;
    public string Nickname;
}
