    using System;
    using System.IO;

    public class TempDirectory : IDisposable
    {
        public string FilePath { get; set; }
        public bool DelteOnDispose { get; set; }

        public TempDirectory() : this(true)
        {
        }

        public TempDirectory(bool deleteOnDispose)
        {
            this.FilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(this.FilePath);
            this.DelteOnDispose = deleteOnDispose;
        }

        public void Dispose()
        {
            if (this.DelteOnDispose)
            {
                Directory.Delete(this.FilePath, true);
            }
        }

        public override string ToString()
        {
            return this.FilePath;
        }
    }
