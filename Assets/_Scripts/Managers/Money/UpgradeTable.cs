using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    public Dictionary<int, float> waiterMoveSpeeds = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int waiterMoveSpeedIndex = 0;

    public Dictionary<int, int> tipFrequencies = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int tipFrequencyIndex = 0;

    public Dictionary<int, int> waiterNumbers = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int waiterNumberIndex = 0;

    public Dictionary<int, int> tableSizes = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int tableSizeIndex = 0;

    public Dictionary<int, float> chefCookSpeeds = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int chefCookSpeedIndex = 0;

    public Dictionary<int, float> porterMoveSpeeds = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int porterMoveSpeedIndex = 0;

    public Dictionary<int, int> porterNumbers = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int porterNumberIndex = 0;

    public Dictionary<int, int> productQualities = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int productQualityIndex = 0;

    public Dictionary<int, float> scullionMoveSpeeds = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int scullionMoveSpeedIndex = 0;

    public Dictionary<int, float> dishwasherSpeeds = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int dishwasherSpeedIndex = 0;

    public Dictionary<int, int> dishwasherNumbers = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int dishwasherNumberIndex = 0;

    public Dictionary<int, int> scullionNumbers = new(){
        {100, 100},
        {250, 250},
        {500, 500} };
    public int scullionNumberIndex = 0;

}
