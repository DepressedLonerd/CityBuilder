using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement;
    public Button PlaceRoadButton, PlaceHouseButton, PlaceSpecialButton;

    public Color outlineColor;
    List<Button> buttonList;
}
