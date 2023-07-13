using UnityEngine;
using UnityEngine.Events;

public class CheatsInput : MonoBehaviour
{
    [System.Serializable]
    public class CheatCode
    {
        public string cheatKey;          // PlayerPrefs key for storing cheat state
        public KeyCode[] sequence;       // Array of key codes representing the cheat sequence
        public UnityEvent onCheatActivated;   // Event invoked when the cheat is activated
        public UnityEvent onCheatDeactivated; // Event invoked when the cheat is deactivated
    }

    public CheatCode[] cheatCodes;       // Array of cheat codes

    private int currentCodeIndex = -1;   // Index of the currently entered cheat code
    private int currentSequenceIndex = 0; // Index to track the current position in the cheat sequence

    void Update()
    {
        // Check for key presses
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                KeyCode key = vKey;

                PressKey(key);  // Call PressKey() method with the pressed key
            }
        }
    }

    void PressKey(KeyCode k)
    {
        if (currentCodeIndex < 0)
        {
            // No cheat code is currently entered, check for a matching cheat code
            for (int i = 0; i < cheatCodes.Length; i++)
            {
                if (k == cheatCodes[i].sequence[0])
                {
                    currentCodeIndex = i;
                    currentSequenceIndex = 1; // Start at the second key in the sequence
                    break;
                }
            }
        }
        else
        {
            // A cheat code is currently entered, check for the next key in the sequence
            CheatCode currentCode = cheatCodes[currentCodeIndex];

            if (k == currentCode.sequence[currentSequenceIndex])
            {
                currentSequenceIndex++;

                if (currentSequenceIndex >= currentCode.sequence.Length)
                {
                    // Entire cheat sequence entered correctly
                    ActivateCheat(currentCode);
                }
            }
            else
            {
                // Incorrect key entered, reset the cheat code
                currentCodeIndex = -1;
                currentSequenceIndex = 0;
            }
        }
    }

    void ActivateCheat(CheatCode cheatCode)
    {
        // Toggle the cheat state in PlayerPrefs
        int currentState = PlayerPrefs.GetInt(cheatCode.cheatKey, 0);
        int newState = 1 - currentState;
        PlayerPrefs.SetInt(cheatCode.cheatKey, newState);

        if (newState == 1)
        {
            // Invoke the cheat activation event
            cheatCode.onCheatActivated?.Invoke();
        }
        else
        {
            // Invoke the cheat deactivation event
            cheatCode.onCheatDeactivated?.Invoke();
        }

        // Reset the cheat code
        currentCodeIndex = -1;
        currentSequenceIndex = 0;
    }
}
