public VideoDownloadOptions GetOptions(string filename, string folder)
        {
            VideoDownloadOptions options = new VideoDownloadOptions
            {
                DownloadThreads = (int)numDownloadThreads.Value,
                ThrottleKib = Settings.Default.DownloadThrottleEnabled
                    ? Settings.Default.MaximumBandwidthKib
                    : -1,
                Filename = filename ?? Path.Combine(folder, FilenameService.GetFilename(Settings.Default.TemplateVod, textTitle.Text, currentVideoId.ToString(), currentVideoTime, textStreamer.Text, streamerId,
                    checkStart.IsChecked == true ? new TimeSpan((int)numStartHour.Value, (int)numStartMinute.Value, (int)numStartSecond.Value) : TimeSpan.Zero,
                    checkEnd.IsChecked == true ? new TimeSpan((int)numEndHour.Value, (int)numEndMinute.Value, (int)numEndSecond.Value) : vodLength,
                    vodLength, viewCount, game) + FilenameService.GuessVodFileExtension(((ComboBoxItem)comboQuality.SelectedItem).Tag.ToString())),
                Oauth = TextOauth.Text,
                Quality = ((ComboBoxItem)comboQuality.SelectedItem).Tag.ToString(),
                Id = currentVideoId,
                TrimBeginning = checkStart.IsChecked.GetValueOrDefault(),
                TrimBeginningTime = new TimeSpan((int)numStartHour.Value, (int)numStartMinute.Value, (int)numStartSecond.Value),
                TrimEnding = checkEnd.IsChecked.GetValueOrDefault(),
                TrimEndingTime = new TimeSpan((int)numEndHour.Value, (int)numEndMinute.Value, (int)numEndSecond.Value),
                // ↓↓↓ **追加した設定をここで代入** ↓↓↓
                DownloadChatWithVideoTime = CheckDownloadChatWithVideoTime.IsChecked.GetValueOrDefault(false),
                // ↑↑↑ **追加した設定をここで代入** ↑↑↑
                FfmpegPath = "ffmpeg",
                TempFolder = Settings.Default.TempPath
            };

            if (RadioTrimSafe.IsChecked == true)
                options.TrimMode = VideoTrimMode.Safe;
            else if (RadioTrimExact.IsChecked == true)
                options.TrimMode = VideoTrimMode.Exact;

            return options;
        }
