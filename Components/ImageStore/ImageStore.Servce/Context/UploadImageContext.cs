using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using ImageStore.Services.Files;

namespace ImageStore.Services.Context
{
    public class UploadImageContext : IDisposable
    {
        private readonly BaseFile _imageFile;
        private Stream _stream;
        private long _contentLength;
        private string _fileName;

        /// <summary>
        /// �����ļ��������
        /// </summary>
        /// <param name="fileName"></param>
        public UploadImageContext(string fileName)
        {
            _imageFile = new LocalFile(fileName);
            _stream = _imageFile.Stream;
            _contentLength = _imageFile.ContentLength;
            _fileName = _imageFile.FileName;
        }

        /// <summary>
        /// ͼƬ�����ļ�
        /// </summary>
        /// <param name="baseFile"></param>
        public UploadImageContext(Stream stream, string fileName)
        {
            _stream = stream;
            _fileName = fileName;
            _contentLength = _stream.Length;
        }

        /// <summary>
        /// �����ļ��������
        /// </summary>
        /// <param name="httpPostedFile"></param>
        public UploadImageContext(HttpPostedFileBase httpPostedFile)
        {
            _imageFile = new NetworkFile(httpPostedFile);
            _stream = _imageFile.Stream;
            _contentLength = _imageFile.ContentLength;
            _fileName = _imageFile.FileName;

        }

        

        /// <summary>
        /// ԭʼͼƬ������
        /// </summary>
        public Stream ImageStream 
        {
            get { return _stream; }
         
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public long ContentContentLength 
        {
            get { return _contentLength; } 
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
        }
        
        /// <summary>
        /// ԭʼ�ļ�Url
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// ѹ���ļ�Url
        /// </summary>
        public string CompressUrl { get; set; }

        /// <summary>
        /// СͼƬUrl
        /// </summary>
        public string ThumbUrl { get; set; }

        /// <summary>
        /// ͼƬ��׺ 
        /// </summary>
        public string ImageExt
        {
            get { return Path.GetExtension(_fileName); }
        }

        /// <summary>
        /// ͼƬ��ʽ
        /// </summary>
        public ImageFormat ImageFormat 
        { 
            get
            {
                switch (ImageExt.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        return ImageFormat.Jpeg;
                    case ".gif":
                        return ImageFormat.Gif;
                    case ".bmp":
                        return ImageFormat.Bmp;
                    case ".tif":
                        return ImageFormat.Tiff;
                    case ".ico":
                        return ImageFormat.Icon;
                    case ".png":
                        return ImageFormat.Png;
                    case ".emf":
                        return ImageFormat.Emf;
                    case "image/x-exif":
                        return ImageFormat.Exif;
                    case "image/x-wmf":
                        return ImageFormat.Wmf;
                    default:
                        return ImageFormat.MemoryBmp;
                }
            }
        }

        /// <summary>
        /// �ر��ļ�
        /// </summary>
        public void Close()
        {
            if (_imageFile != null)
            {
                _imageFile.Close();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);////�ͷ��й���Դ
            GC.SuppressFinalize(this);//����ϵͳ��Ҫ����ָ��������ս���. //�÷����ڶ���ͷ������һ��λ��ϵͳ�ڵ����ս���ʱ��������λ
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)//_isDisposedΪfalse��ʾû�н����ֶ�dispose
            {
                if (disposing)
                {
                    Close();
                }
            }
            _isDisposed = true;
        }

        private bool _isDisposed;

        ~UploadImageContext()
        {
            this.Dispose(false);//�ͷŷ��й���Դ���й���Դ���ռ����Լ������
        }
    }
}