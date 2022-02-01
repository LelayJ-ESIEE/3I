using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Linq;
using Random = UnityEngine.Random;

[System.Serializable]
public class MyAudioClip
{
	public MyAudioClip(AudioClip clip,float volume)
	{
		this.clip = clip;
		this.volume = volume;
	}

	public AudioClip clip;
	public float volume;
}

/// <summary>
/// Sfx manager.
/// </summary>
public class SfxManager : Singleton<SfxManager> {

	[Header("SfxManager")]
	[SerializeField] TextAsset m_SfxXmlSetup;
	[SerializeField] string m_ResourcesFolderName;

	[SerializeField] int m_NAudioSources = 2;

	[SerializeField] bool m_ShowGui;

	List<AudioSource> m_AudioSources = new List<AudioSource>();
	Dictionary<string,MyAudioClip> m_DicoAudioClips = new Dictionary<string, MyAudioClip>();

	AudioSource AddAudioSource()
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		m_AudioSources.Add(audioSource);
		
		audioSource.loop = false;
		audioSource.playOnAwake = false;

		return audioSource;
	}

	// Use this for initialization
	void Start () {

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(m_SfxXmlSetup.text);

		foreach(XmlNode node in xmlDoc.GetElementsByTagName("SFX"))
		{
			if(node.NodeType!= XmlNodeType.Comment)

			m_DicoAudioClips.Add(
				node.Attributes["name"].Value,
			    new MyAudioClip(
				(AudioClip)Resources.Load(m_ResourcesFolderName+"/"+node.Attributes["name"].Value,typeof(AudioClip)),
				float.Parse(node.Attributes["volume"].Value)));
		}

		for (int i = 0; i < m_NAudioSources; i++) 
			AddAudioSource();
	}

	public void PlaySfx(string sfxName)
	{
		if(FlagsManager.Instance && !FlagsManager.Instance.GetFlag("SETTINGS_SFX",true))
			return;

		MyAudioClip audioClip;
		if(!m_DicoAudioClips.TryGetValue(sfxName,out audioClip))
		{
			Debug.LogError("SFX, no audio clip with name: "+sfxName);
			return;
		}

		AudioSource audioSource = m_AudioSources.Find(item=>!item.isPlaying);
		if(audioSource) 
			audioSource.PlayOneShot(audioClip.clip,audioClip.volume);

	}

	void OnGUI()
	{
		if(!m_ShowGui) return;


		GUILayout.BeginArea(new Rect(Screen.width*.5f+10,10,200,Screen.height));
		GUILayout.Label("SFX MANAGER");
		GUILayout.Space(20);
		foreach (var item in m_DicoAudioClips) {
			if(GUILayout.Button("PLAY "+item.Key))
				PlaySfx(item.Key);
		}
		GUILayout.EndArea();
	}
}
