using System;
using System.IO;
using TwitchDownloaderCore.Models;
using TwitchDownloaderCore.TwitchObjects; // ChatClientEnum, ChatEmbedData, ChatCompression の型定義を使用するために必要

namespace TwitchDownloaderCore.Options
{
    public class VideoDownloadOptions
    {
        public long Id { get; set; }
        public string Quality { get; set; }
        public string Filename { get; set; }
        public bool TrimBeginning { get; set; }
        public TimeSpan TrimBeginningTime { get; set; }
        public bool TrimEnding { get; set; }
        public TimeSpan TrimEndingTime { get; set; }
        public int DownloadThreads { get; set; }
        public int ThrottleKib { get; set; }
        public string Oauth { get; set; }
        public string FfmpegPath { get; set; }
        public string TempFolder { get; set; }
        public Func<DirectoryInfo[], DirectoryInfo[]> CacheCleanerCallback { get; set; }
        public Func<FileInfo, FileInfo> FileCollisionCallback { get; set; } = info => info;
        public VideoTrimMode TrimMode { get; set; }
        public bool DelayDownload { get; set; }

        // --- チャットダウンロード関連のプロパティ ---
        
        public bool DownloadChat { get; set; }
        public ChatClientEnum ChatClient { get; set; }
        public int ChatConnectionCount { get; set; } = 1;

        /// <summary>
        /// VODのクロップ時間をチャットダウンロードにも適用するかどうか
        /// </summary>
        public bool DownloadChatWithVideoTime { get; set; }

        public ChatEmbedData EmbedData { get; set; }
        public bool BttvEmotes { get; set; }
        public bool FfzEmotes { get; set; }
        public bool StvEmotes { get; set; }
        public TimeSpan ChatTimezone { get; set; }
        public ChatCompression ChatCompression { get; set; }
    }
}
