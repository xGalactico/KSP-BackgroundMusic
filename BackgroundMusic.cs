using System.Collections.Generic;
using UnityEngine;

namespace BackgroundMusic
{
    [KSPAddon(startup: KSPAddon.Startup.MainMenu, once: false)]
    public class BackgroundMusic : MonoBehaviour
    {      
        private MusicLogic music;

        private const string suffix_space = "Space";
        private const string suffix_construction = "Construction";

        private bool isInDebugMode = false;

        public void Awake()
        {
            Utils.Log("Starting...");

            music = MusicLogic.fetch;
        }

        public void Start()
        {
            string p = $"{Info.modName}/{Info.pathFiles}/";
            List<AudioClip> db = GameDatabase.Instance.databaseAudio.FindAll(c => c.ToString().StartsWith(p));

            if (db.Count > 0)
            {
                music.spacePlaylist.Clear();
                music.constructionPlaylist.Clear();

                for (int i = 0; i < db.Count; i++)
                {
                    if (db[i].ToString().Contains(suffix_space))
                        music.spacePlaylist.Add(db[i]);

                    else if (db[i].ToString().Contains(suffix_construction))
                        music.constructionPlaylist.Add(db[i]);

                    if (isInDebugMode)
                        Utils.Log("Playlist" + db[i].name);
                }
            }
        }
    }
}
