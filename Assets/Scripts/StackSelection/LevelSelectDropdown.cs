using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectDropdown : MonoBehaviour
{


    //TODO provide scene names for all levels
    Dictionary<string, string> levelNames = new Dictionary<string, string>() {
        {"Default Physics Race", "RacePhysics"},
        {"Old Race Scene", "Race"}
    };


    private Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();

        List<string> options = new List<string>();
        foreach(string title in levelNames.Keys) {
            options.Add(title);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string getSelectedRaceScene(){
        string title = dropdown.options[dropdown.value].text;

        if (levelNames.ContainsKey(title)) {
            return levelNames[title];
        } else {
            return null;
        }
    }

}
