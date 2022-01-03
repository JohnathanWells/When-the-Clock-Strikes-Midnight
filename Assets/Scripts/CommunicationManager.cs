using UnityEngine;
using Ink.Runtime;
using UnityEngine.Events;

public class CommunicationManager : MonoBehaviour
{
	CommunicationSubject activeSubject;
	Story activeConversation;
	public RectTransform conversationWindow;
	public RectTransform decisionParent;
	public CommunicationDecision buttonPrefab;
	CommunicationDecision[] choiceButtons;
	public UnityEvent OnConversationStart;
	public UnityEvent OnConversationEnd;

	[Header("Display")]
	public SubtitleManager dialogueTextManager;
	public float defaultSecondsPerCharacter = 0.01f;

	public static CommunicationManager Instance;

    private void Start()
    {
		Instance = this;
    }

	public void LoadSubject(CommunicationSubject subject)
    {
		this.activeSubject = subject;
		LoadConversation(activeSubject.story);
    }

	public void ChangeSecondsPerCharacter(float to)
    {
		if (to > 0)
			dialogueTextManager.secondPerCharacter = to;
		else
			dialogueTextManager.secondPerCharacter = defaultSecondsPerCharacter;
    }

    public void LoadConversation(Story asset)
    {
        activeConversation = asset;
		LoadIntoStoryVariables(asset);
    }

    public void StartConversation()
    {
		OnConversationStart.Invoke();
		conversationWindow.gameObject.SetActive(true);
		DisplayText();
    }

	public void EndConversation()
    {
		LoadFromStoryVariables(activeConversation);
		OnConversationEnd.Invoke();
		activeSubject.OnConversationEnd.Invoke();
		conversationWindow.gameObject.SetActive(false);
    }

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void DisplayText()
	{
		ClearChoices();
		dialogueTextManager.ClearMessages();

		// Read all the content until we can't continue any more
		while (activeConversation.canContinue)
		{
			// Continue gets the next line of the story
			string text = activeConversation.Continue();
			//if (text.Contains(":"))
   //         {
			//	string[] strs = text.Split(':');
			//	dialogueTextManager.preface = string.Format("<b>{0}:</b> ", strs[0]);
			//	text = strs[1];
   //         }
			//else
   //         {
			//	dialogueTextManager.preface = "";
   //         }

			// This removes any white space from the text.
			text = text.Trim();
			dialogueTextManager.DisplayMessage(text);
		}
		
	}

	public void DisplayOptions()
    {
		// Display all the choices, if there are any!
		if (activeConversation.currentChoices.Count > 0)
		{

			decisionParent.gameObject.SetActive(true);
			choiceButtons = new CommunicationDecision[activeConversation.currentChoices.Count];

			for (int i = 0; i < activeConversation.currentChoices.Count; i++)
			{
				Choice choice = activeConversation.currentChoices[i];

				CommunicationDecision temp = Instantiate(buttonPrefab, decisionParent);
				temp.Set(choice);

				choiceButtons[i] = temp;

				// Tell the button what to do when we press it
				choiceButtons[i].button.onClick.AddListener(delegate {
					OnClickChoiceButton(choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			//dialogueTextManager.ClearMessages();
			//dialogueTextManager.ClearQueue();
			decisionParent.gameObject.SetActive(false);
		}
	}



	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		activeConversation.ChooseChoiceIndex(choice.index);
		DisplayText();
	}

	void ClearChoices()
    {
		int childCount = decisionParent.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(decisionParent.transform.GetChild(i).gameObject);
		}
	}

	public void EndIfEmpty()
    {
		if (!activeConversation.canContinue && activeConversation.currentChoices.Count == 0)
			EndConversation();
    }

	public void LoadIntoStoryVariables(Story story)
    {
		foreach(System.Collections.Generic.KeyValuePair<string, int> s in MysteryManager.facts)
        {
			
			if (story.variablesState.GlobalVariableExistsWithName(s.Key))
            {
				story.variablesState[s.Key] = s.Value;
            }
        }
    }

	public void LoadFromStoryVariables(Story story)
    {
		foreach (var s in story.variablesState)
		{
			//Debug.Log(s);
			if(MysteryManager.facts.ContainsKey(s))
			{
				MysteryManager.facts[s] = (int)story.variablesState[s];
			}
			else
            {
				MysteryManager.facts.Add(s, (int)story.variablesState[s]);
            }
		}
	}
}
