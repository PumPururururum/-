using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Text;
using System;


public class ScoreManager : MonoBehaviour
{

    public int GlobalScore;
    public int StorageScore;
    public int PhoneScore;
    public int PassScore = 0;
    public void PrintStrongNess(string input)
    {
        // Checking lower alphabet in string 
        int n = input.Length;
        bool hasLower = false, hasUpper = false,
                hasDigit = false, specialChar = false;
        HashSet<char> set = new HashSet<char>(
            new char[] { '!', '@', '#', '$', '%', '^', '&',
                          '*', '(', ')', '-', '+' });
        foreach (char i in input.ToCharArray())
        {
            if (char.IsLower(i))
                hasLower = true;
            if (char.IsUpper(i))
                hasUpper = true;
            if (char.IsDigit(i))
                hasDigit = true;
            if (set.Contains(i))
                specialChar = true;
        }

        // Strength of password 
        //Console.Write("Strength of password:- ");
        if (hasDigit && hasLower && hasUpper && specialChar
            && (n >= 12))
            PassScore = 5;
        //Console.Write(" Very Strong");
        else if (((hasLower && hasUpper || specialChar) && hasDigit)
                 && (n >= 8))
            //Console.Write(" Strong");
            PassScore = 4;
        else if (((hasLower || hasUpper || specialChar)  && hasDigit) && (n >= 6))
            // Console.Write(" Moderate");
            PassScore = 3;
        else if ((hasLower || hasUpper || hasDigit) && n >= 4)
            PassScore = 2;
        else PassScore = 1;
    }
    public void AddPhoneScore()
    {
        PhoneScore = 1;
    }

    public int EndScore()
    {

        
        PrintStrongNess(PlayerPrefs.GetString("PlayerPassword"));
        GlobalScore = PassScore + PhoneScore + StorageScore;
        return GlobalScore;
    }
}
