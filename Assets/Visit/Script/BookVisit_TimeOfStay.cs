using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BookVisit_TimeOfStay : MonoBehaviour
{
    public TMP_InputField Start;
    public TMP_InputField End;


    public void ValidateTimeInputField(TMP_InputField timeInputField)
    {
        HashSet<char> validChar = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ':' };
        bool IsValidChar(char c) { return validChar.Contains(c); }


        if (string.IsNullOrEmpty(timeInputField.text))
        {
            timeInputField.text = ":";
            timeInputField.caretPosition = 0;
            return;
        }
        else
        {
            for (int i = 0; i < timeInputField.text.Length; i++)
            {
                var c = timeInputField.text[i];
                if (!IsValidChar(c))
                {
                    timeInputField.text = ":";
                    timeInputField.caretPosition = 0;
                    return;
                }
            }
        }

        if (timeInputField.text.Length >= 5)
        {
            timeInputField.text = timeInputField.text.Substring(0, 5);
        }

        if (timeInputField.text.Length >= 2)
        {
            var _inputStr = timeInputField.text;
            _inputStr = _inputStr.Replace(":", "");
            if (_inputStr.Length > 1)
                timeInputField.text = _inputStr.Insert(2, ":");
        }

        //timeInputField.MoveTextEnd(false);
    }
}
