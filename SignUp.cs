using System;

[Serializable]
public class SignUpData
{
	public string type;
	public string message;
}

[Serializable]
public class SignUp
{
	public SignUpData data;
}