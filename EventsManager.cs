using UnityEngine;
using System.Collections;

public class EventsManager : SingletonEternal<EventsManager> 
{
	public ParameterlessDelegate CreateSolitareGameEvent;
	public ParameterlessDelegate won;
	public ParameterlessDelegate lost;
	public StringDelegate CreateGuruGameEvent;
	public CardDelegate cardSelectedEvent;
	public CardDelegate cardDeSelectedEvent;
	public WordDelegate wordFound;

}
