using System.Collections.Concurrent;
using System.IO;

namespace Meancat.EliteBinding.Reader
{
    public class BindingWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly ConcurrentQueue<string> _changedFiles = new();

        public BindingWatcher(string path)
        {
            _watcher = new FileSystemWatcher(path);
            _watcher.Changed += OnChanged;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            // don't process in background thread
            _changedFiles.Enqueue(e.FullPath);
        }

        public bool TryGetChangedFile(out string? filePath)
        {
            return _changedFiles.TryDequeue(out filePath);
        }
    }
}
