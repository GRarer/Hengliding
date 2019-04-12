using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HenSelectionControl : MonoBehaviour
{

    public GameObject listItemPrefab;
    public VerticalLayoutGroup verticalLayout;

    public SelectionStatsDisplay displayBox;

    List<StackSelectionListItem> listItems;

    public StartRaceButton StartButton;
    public selectionPortrait portrait;
    public Text nameText;

    public Button nextButton;
    public Button lastButton;

    List<HenInfo> henList;
    int currentHenIndex;
    HenInfo currentHen;
    

    // Start is called before the first frame update
    void Start()
    {

        nextButton.onClick.AddListener(delegate{selectNext();});
        lastButton.onClick.AddListener(delegate{selectPrev();});

        listItems = new List<StackSelectionListItem>();

        henList = HenInfoPersist.loadList();
        currentHenIndex = 0;
        updateSelection();
    }


    public void selectNext() {
        currentHenIndex++;

        if (currentHenIndex >= henList.Count) {
            currentHenIndex = 0;
        }
        
        updateSelection();
    }

    public void selectPrev() {
        currentHenIndex--;
        if (currentHenIndex < 0) {
            currentHenIndex = henList.Count - 1;
        }
        
        updateSelection();
    }

    public void updateSelection() {
        currentHen = henList[currentHenIndex];
        portrait.updateImage(currentHen);
        nameText.text = currentHen.name;
        updateStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateStats() {
        //compute selection
        List<HenInfo> selectedHens = new List<HenInfo>();
        selectedHens.Add(currentHen);

        RaceStatsCalculator.calculateStats(selectedHens);
        displayBox.updateStats();
        StartButton.updateButton();
    }


}
