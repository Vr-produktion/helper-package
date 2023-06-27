using System.ComponentModel.Design;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;





class HelperSystemSettings : EditorWindow
{
    private string myData = "";
    bool groupEnabled;

    bool myStoryLine = true;
    bool myTriggerOnce = true;
    bool myContextualHints = true;

    float myTimeout = 2f;







    // Add menu item named "My Window" to the Window menu
    [MenuItem("Helper system/Settings")]
    public static void ShowWindow()
    {

       

        string loadedData=File.ReadAllText(Application.dataPath+ "/help module/code/data/SaveFile.json");


        HelpSystemDataObject loadedObject=JsonUtility.FromJson<HelpSystemDataObject>(loadedData);

        Debug.Log(loadedObject.dataFile);




        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(HelperSystemSettings));
    }

    void OnGUI()
    {
        GUILayout.Label("System Settings", EditorStyles.boldLabel);

        myData = EditorGUILayout.TextField("Data File", myData);


        //groupEnabled = EditorGUILayout.BeginToggleGroup("Customize Settings", groupEnabled);

        myStoryLine = EditorGUILayout.Toggle("Story line help", myStoryLine);

        myTriggerOnce = EditorGUILayout.Toggle("Trigger story line once", myTriggerOnce);

        myContextualHints = EditorGUILayout.Toggle("Contextual hints", myContextualHints);


        myTimeout = EditorGUILayout.Slider("Timeout period in seconds", myTimeout, 0, 120);
       //EditorGUILayout.EndToggleGroup();

        
        if (GUILayout.Button("Save settings"))
        {
            SaveSettings();
        }
        
    }


    void SaveSettings()
    {

        /*
        // Create a custom game object
        // GameObject go = new GameObject("Help trigger");

        GameObject myPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/help module/helperTrigger.prefab", typeof(GameObject));





        HelpSystemData DataAsset = ScriptableObject.CreateInstance<HelpSystemData>();


        DataAsset.storyLineSetting = myStoryLine;
        DataAsset.myTriggerOnceSetting = myTriggerOnce; 
        DataAsset.contextualHintsSettings = myContextualHints;
        DataAsset.WaitPeriodSettings = myTimeout;


        AssetDatabase.CreateAsset(DataAsset, "Assets/help module/code/data/HelpSystemData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = DataAsset;
        */

        HelpSystemDataObject helpSystemDataObject = new HelpSystemDataObject();

        helpSystemDataObject.dataFile = myData;

        helpSystemDataObject.storyLineSetting = myStoryLine;
        helpSystemDataObject.myTriggerOnceSetting = myTriggerOnce;
        helpSystemDataObject.contextualHintsSettings = myContextualHints;
        helpSystemDataObject.WaitPeriodSettings = myTimeout;

        string json = JsonUtility.ToJson(helpSystemDataObject);

       // Debug.Log(json);


        File.WriteAllText(Application.dataPath + "/help module/code/data/SaveFile.json", json);

    }

    /*
    private class HelpSystemDataObject
    {
        public string dataFile = "myData";
        public bool storyLineSetting = true;
        public bool myTriggerOnceSetting = true;
        public bool contextualHintsSettings = true;
        public float WaitPeriodSettings = 2f;


        public string[] versions;

    }

   */


}


