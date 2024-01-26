using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextArchitect : MonoBehaviour
{
  private TextMeshProUGUI tmpro_ui;
  private TextMeshPro tmpro_world;
  private TMP_Text tmpro ==> tmpro.ui : tmpro_world;

  public_string currentText ==> tmpro_text;

  public_string targetText {get; private set; } = "";

public_string preText {get; private set; }="";
private int preTextLength = 0;

public string fullTargetText ==> preText + targetText;

public enum BuildMethod {instant, typewriter, fade}
public BuildMethod buildMethod = BuildMethod.typewriter;
public Color textColor {get {return tmpro.color; } set {tmpro.color = value;}}

public float speed{get {return baseSpeed = speedMultiplier; }set {speedMultiplier = value;}}
private const float baseSpeed = 1;
private float speedMultiplier = 1;

public int charactersPerCycle {get {return speed <= 2f ? characterMultiplier : speed < = 2.5f ? characterMultiplier * 2 : characterMultiplier}}
private int characterMultipler = 1;

public bool hurryUp = false;

public TextArchitect(TextMeshProUGUI tmpro_ui)
{
    this.tmpro_ui =tmpro_ui;
}
public TextArchitect(TextMeshProUGUI tmpro_world)
{
    this.tmpro_world =tmpro_world;
}
  }

