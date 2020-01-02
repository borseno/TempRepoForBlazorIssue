﻿using System;
using System.IO;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class FileSavingService : IFileSavingService
    {
        private readonly string folder;

        public FileSavingService(string folder)
        {
            this.folder = folder;
        }
        
        /// <summary>
        /// Saves file to a specific directory (subpath) that is in wwwroot directory. 
        /// </summary>
        /// <param name="bytesEncoded">bytes of the image encoded in 64 base string</param>
        /// <param name="fileType">html file type such as "images/jpg"</param>
        /// <param name="subpath">subpath of wwwroot directory to save file at</param>
        /// <returns>returns local in terms of wwwroot folder filename</returns>
        public Task<string> SaveFileAsync(string bytesEncoded, string fileType, string subpath)
        {
            byte[] bytes = Convert.FromBase64String(bytesEncoded);

            return SaveFileAsync(bytes, fileType, subpath);
        }

        public Task<string> SaveFileAsync(byte[] bytes, string fileType, string subpath)
        {
            return SaveFileAsync(bytes, fileType, subpath, folder);
        }

        private static async Task<string> SaveFileAsync(byte[] bytes, string fileType, string subpath, string folder)
        {
            var localFilePath = GetLocalFilePath(fileType, subpath);
            var path = Path.Combine(folder, localFilePath);

            using (var sw = File.Create(path, bytes.Length, FileOptions.Asynchronous))
            {
                await sw.WriteAsync(bytes);
            }

            return localFilePath;
        }

        private static string GetLocalFilePath(string fileType, string subpath)
        {
            var fileName = Path.ChangeExtension(Guid.NewGuid().ToString(), fileType);
            var localFilePath = Path.Combine(subpath, fileName);

            return localFilePath;
        }
    }
}
