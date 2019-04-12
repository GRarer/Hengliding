using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HenSelectionControl : MonoBehaviour {

	public GameObject listItemPrefab;

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


	public SoundOptions soundOptions;
	public SoundManager 死;


	// Start is called before the first frame update
	void Start() {

		nextButton.onClick.AddListener(delegate { selectNext(); });
		lastButton.onClick.AddListener(delegate { selectPrev(); });

		listItems = new List<StackSelectionListItem>();

		henList = HenInfoPersist.loadList();
		currentHenIndex = 0;
		updateSelection();

		死 = SoundManager.Instance();
		soundOptions = SoundOptions.Instance();
		if (Random.Range(0.0f, 1.0f) > 0.5) {
			死.SetBGM(SoundManager.SFX.chickenMarch);
			死.PlayBGM();
		} else {
			死.SetBGM(SoundManager.SFX.chickenMarchDubstep);
			死.PlayBGM();
		}
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
	void Update() {

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
