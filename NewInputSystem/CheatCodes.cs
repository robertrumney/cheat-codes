using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem; // Required for the new Input System

public class CheatCodes : MonoBehaviour
{
    // Serializable class to hold cheat code data
    [System.Serializable]
    public class CheatCode
    {
        public string cheatKey; // PlayerPrefs key for storing cheat state
        public Key[] sequence; // Array of keys representing the cheat sequence (using Key instead of KeyCode)
        public UnityEvent onCheatActivated; // Event invoked when the cheat is activated
        public UnityEvent onCheatDeactivated; // Event invoked when the cheat is deactivated
        public bool saveCheat = true; // Indicates whether to save the cheat state
    }

    public CheatCode[] cheatCodes; // Array of cheat codes

    // Variables to keep track of the current cheat code and sequence position
    private int currentCodeIndex = -1;
    private int currentSequenceIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // Iterate through cheat codes to restore saved states
        foreach (CheatCode cheat in cheatCodes)
        {
            if (cheat.saveCheat)
            {
                // Retrieve saved state and trigger appropriate event
                int savedState = PlayerPrefs.GetInt(cheat.cheatKey, 0);
                if (savedState == 1)
                {
                    cheat.onCheatActivated?.Invoke();
                }
                else
                {
                    cheat.onCheatDeactivated?.Invoke();
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Get the current keyboard state
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return; // If no keyboard is found, exit the method

        // Check if a key in any cheat code sequence was pressed
        foreach (CheatCode cheatCode in cheatCodes)
        {
            if (currentCodeIndex == -1 || cheatCode == cheatCodes[currentCodeIndex])
            {
                for (int i = 0; i < cheatCode.sequence.Length; i++)
                {
                    if (keyboard[cheatCode.sequence[i]].wasPressedThisFrame)
                    {
                        // Call PressKey with the pressed key and the cheat code it belongs to
                        PressKey(cheatCode.sequence[i], cheatCode);
                        break; // Break after the first key press is found
                    }
                }
            }
        }
    }

    // Method to handle key press for cheat codes
    private void PressKey(Key k, CheatCode cheatCode)
    {
        // Check if starting a new cheat code or continuing an existing one
        if (currentCodeIndex < 0)
        {
            // Check for a matching cheat code start
            for (int i = 0; i < cheatCodes.Length; i++)
            {
                if (k == cheatCodes[i].sequence[0])
                {
                    // Set the current cheat code and sequence index
                    currentCodeIndex = i;
                    currentSequenceIndex = 1; // Start at the second key in the sequence
                    break;
                }
            }
        }
        else if (cheatCode == cheatCodes[currentCodeIndex])
        {
            // Check for the next key in the sequence
            if (k == cheatCode.sequence[currentSequenceIndex])
            {
                // Increment sequence index
                currentSequenceIndex++;

                // Check if the entire cheat sequence was entered
                if (currentSequenceIndex >= cheatCode.sequence.Length)
                {
                    // Activate the cheat
                    ActivateCheat(cheatCode);
                }
            }
            else
            {
                // Incorrect key entered, reset the cheat code tracking
                currentCodeIndex = -1;
                currentSequenceIndex = 0;
            }
        }
    }

    // Method to activate or deactivate a cheat
    private void ActivateCheat(CheatCode cheatCode)
    {
        // Toggle the cheat state in PlayerPrefs
        int currentState = PlayerPrefs.GetInt(cheatCode.cheatKey, 0);
        int newState = 1 - currentState;
        PlayerPrefs.SetInt(cheatCode.cheatKey, newState);

        // Invoke the appropriate event based on the new cheat state
        if (newState == 1)
        {
            cheatCode.onCheatActivated?.Invoke();
        }
        else
        {
            cheatCode.onCheatDeactivated?.Invoke();
        }

        // Reset the cheat code tracking
        currentCodeIndex = -1;
        currentSequenceIndex = 0;
    }
}
