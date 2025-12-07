using System;
using System.IO;
using TwitchDownloaderCore.Models;
using TwitchDownloaderCore.TwitchObjects; // ChatClientEnum, ChatEmbedData, ChatCompression などの型定義を使用するために追加

namespace TwitchDownloaderCore.Options
{
    public class ChatDownloadOptions
    {
        public ChatFormat DownloadFormat { get; set; } = ChatFormat.Json;
        public long Id { get; set; } // stringからlongに変更
        public string Filename { get; set; }
        public ChatCompression Compression { get; set; } = ChatCompression.None;

        // VODトリム時間に合わせて追加
        public TimeSpan CropBeginning { get; set; } 
        public TimeSpan CropEnd { get; set; }
        
        // ChatClient/Connection/Timezoneのプロパティ
        public ChatClientEnum ClientMode { get; set; } 
        public int ConnectionCount { get; set; } = 1;
        public TimeSpan Timezone { get; set; }

        public bool EmbedData { get; set; }
        public bool BttvEmotes { get; set; }
        public bool FfzEmotes { get; set; }
        public bool StvEmotes { get; set; }
        public int DownloadThreads { get; set; } = 1;
        public TimestampFormat TimeFormat { get; set; }
        public string FileExtension
        {
            get
            {
                return string.Concat(
                    DownloadFormat switch
                    {
                        ChatFormat.Json => ".json",
                        ChatFormat.Html => ".html",
                        ChatFormat.Text => ".txt",
                        _ => ""
                    },
                    Compression switch
                    {
                        ChatCompression.None => "",
                        ChatCompression.Gzip => ".gz",
                        _ => ""
                    }
                );
            }
        }
        public string TempFolder { get; set; }
        public Func<FileInfo, FileInfo> FileCollisionCallback { get; set; } = info => info;
        public bool DelayDownload { get; set; }
    }
}
