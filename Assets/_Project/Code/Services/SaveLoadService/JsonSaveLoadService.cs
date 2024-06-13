using System;
using System.IO;
using _Project.Code.Core.Util;
using _Project.Code.Data;
using Newtonsoft.Json;
using UnityEngine.Device;

namespace _Project.Code.Services.SaveLoadService
{
    public sealed class JsonSaveLoadService : ISaveLoadService
    {
        private readonly string _filePath = Application.persistentDataPath + Constants.AssetPath.PlayerProgress;

        public void Save(PlayerProgress progress)
         {
             string json = JsonConvert.SerializeObject(progress);
             File.WriteAllText(_filePath, json);
         }
        
         public PlayerProgress Load()
         { 
             if (!File.Exists(_filePath))
                 return new PlayerProgress { BestTime = TimeSpan.Zero};
        
             string json = File.ReadAllText(_filePath);
             PlayerProgress progress = JsonConvert.DeserializeObject<PlayerProgress>(json);
             return progress;
         }

        public void Reset() => Save(new PlayerProgress());
    }
}