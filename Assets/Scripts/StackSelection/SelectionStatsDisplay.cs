using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionStatsDisplay : MonoBehaviour
{

 
    public Slider massSlider;
    public Slider wingspanSlider;
    public Slider controlSlider;
    public Slider dragSlider;


    void Start() {
        massSlider.minValue = RaceStatsCalculator.MIN_MASS;
        massSlider.maxValue = RaceStatsCalculator.MAX_MASS;

        wingspanSlider.minValue = RaceStatsCalculator.MIN_WINGSPAN;
        wingspanSlider.maxValue = RaceStatsCalculator.MAX_WINGSPAN;

        controlSlider.minValue = RaceStatsCalculator.MIN_AUTHORITY;
        controlSlider.maxValue = RaceStatsCalculator.MAX_AUTHORITY;

        dragSlider.minValue = RaceStatsCalculator.MIN_DRAG_MULT;
        dragSlider.maxValue = RaceStatsCalculator.MAX_DRAG_MULT;
    }

    public void updateStats() {



        
        float mass =  SelectedRaceParameters.mass;
        float wingspan =  SelectedRaceParameters.wingspan;
        float control = SelectedRaceParameters.controlAuthority;
        float drag = SelectedRaceParameters.dragMultiplier;
       

        Debug.Log("Mass: " + mass);
        Debug.Log("Wing: " + wingspan);
        Debug.Log("COntrol: " + control);
        Debug.Log("Drag: " + drag);

   
        if (mass < 0.8) {
            mass = 0.8f;
        }
        if (wingspan < 0.56f) {
            wingspan = 0.56f;
        }
        if (control < 1.025f) {
            control = 1.025f;
        }
        if (drag < 0.53f) {
            drag = 0.53f;
        }


        massSlider.value = mass;
        wingspanSlider.value = wingspan;
        controlSlider.value = control;
        dragSlider.value = drag;


    }
}
