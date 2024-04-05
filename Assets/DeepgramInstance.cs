using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

using NativeWebSocket;
using UnityEngine.Events;

[System.Serializable]
public class DeepgramResponse
{
    public int[] channel_index;
    public bool is_final;
    public Channel channel;
}

[System.Serializable]
public class Channel
{
    public Alternative[] alternatives;
}

[System.Serializable]
public class Alternative
{
    public string transcript;
}

[System.Serializable]
public class WordMatch
{
    public string[] words;
    public int matchedCount;
}

public class DeepgramInstance : MonoBehaviour
{
    WebSocket websocket;

    [Range(0,1)]
    public float tolerance;
    public UnityEvent[] Events;

    [SerializeField]
    private bool enabledWords = false;

    public bool[] progression;

    public bool NeedTetra = true;

    public bool EnabledWords
    {
        get { return enabledWords; }
        set { enabledWords = value; }
    }

    public List<WordMatch> wordMatches;

    async void Start()
    {
        progression = new bool[wordMatches.Count];

        var headers = new Dictionary<string, string>
        {
            { "Authorization", "Token d8777e1d896ff3e1e0e84534cf2dfb4542c376b2" }
        };
        websocket = new WebSocket("wss://api.deepgram.com/v1/listen?encoding=linear16&sample_rate=" + AudioSettings.outputSampleRate.ToString(), headers);

        websocket.OnOpen += () =>
        {
            Debug.Log("Connected to Deepgram!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error: " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        // Initialize the audioSources array with the AudioSources from OCCReplies objects


        websocket.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage: " + message);

            DeepgramResponse deepgramResponse = JsonUtility.FromJson<DeepgramResponse>(message);
            object boxedDeepgramResponse = deepgramResponse;
            deepgramResponse = (DeepgramResponse)boxedDeepgramResponse;
            if (deepgramResponse.is_final)
            {
                var transcript = deepgramResponse.channel.alternatives[0].transcript;
                Debug.Log(transcript);

                string[] words = transcript.Split(' ');

                // Calculate the number of words that need to match
                int wordsToMatch = Mathf.CeilToInt(words.Length * tolerance);

                // Reset the matched counts
                foreach (var wordMatch in wordMatches)
                {
                    wordMatch.matchedCount = 0;
                }

                foreach (string word in words)
                {
                    // Compare each word to a specific condition
                    // Modify the condition based on your requirements
                    // Reporting to OCC
                    if (EnabledWords)
                    {
                        foreach (var wordMatch in wordMatches)
                        {
                            if (Array.Exists(wordMatch.words, w => w == word))
                            {
                                wordMatch.matchedCount++;
                                break;
                            }
                        }
                    }
                }

                // Check if the matched words exceed the threshold
                for (int i = 0; i < wordMatches.Count; i++)
                {
                    var wordMatch = wordMatches[i];
                    if (wordMatch.matchedCount >= wordsToMatch && progression[i])
                    {
                        DisableProgression();
                        Events[i].Invoke();
                        // Trigger the action here
                        Debug.Log("works" + (i + 1));
                    }
                }
            }
        };

        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
        if (!NeedTetra)
            enabledWords = true;
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

    public async void ProcessAudio(byte[] audio)
    {
        if (websocket.State == WebSocketState.Open)
        {
            await websocket.Send(audio);
        }
    }

    public void RequireTetra()
    {
        NeedTetra = true;
    }
    public void DoesNotRequireTetra()
    {
        NeedTetra = false;
    }

    public void EnableWords()
    {
        EnabledWords = true;
    }

    public void DisableWords()
    {
        EnabledWords = false;
    }

    public void Progresssion(int current)
    {
        for (int i = 0; i < progression.Length; i++)
        {
            if (current == i)
                progression[i] = true;

            else
                progression[i] = false;
        }
    }

    public void DisableProgression()
    {
        for (int i = 0; i < progression.Length; i++)
        {
            progression[i] = false;
        }
    }
}