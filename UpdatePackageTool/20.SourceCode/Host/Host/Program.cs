using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 设置监听的 IP 地址和端口
            string ipAddress = "127.0.0.1";
            int port = 8080;

            // 设置服务根目录路径
            string rootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            // 创建 HTTPListener 对象，并设置监听前缀
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add($"http://{ipAddress}:{port}/");

            // 开始监听
            listener.Start();
            Console.WriteLine($"Listening on http://{ipAddress}:{port}/");

            // 循环处理请求
            while (true)
            {
                // 获取传入的请求上下文
                HttpListenerContext context = listener.GetContext();

                // 处理请求
                ThreadPool.QueueUserWorkItem((_) => HandleRequest(context, rootDirectory));
            }
        }

        static void HandleRequest(HttpListenerContext context, string rootDirectory)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string requestUrl = request.Url.LocalPath.TrimStart('/');

            // 检查请求的路径是否合法
            string filePath = Path.Combine(rootDirectory, requestUrl);
            if (!filePath.StartsWith(rootDirectory))
            {
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                response.Close();
                return;
            }

            // 检查请求的文件是否存在
            if (!File.Exists(filePath))
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Close();
                return;
            }

            // 读取请求文件内容
            byte[] content;
            try
            {
                content = File.ReadAllBytes(filePath);
            } catch
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Close();
                return;
            }

            // 设置响应头
            response.StatusCode = (int)HttpStatusCode.OK;
            response.ContentLength64 = content.Length;
            response.ContentType = GetContentType(Path.GetExtension(filePath));

            // 写入响应内容
            using (Stream outputStream = response.OutputStream)
            {
                outputStream.Write(content, 0, content.Length);
            }

            response.Close();
        }

        static string GetContentType(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".html":
                case ".htm":
                    return "text/html";
                case ".txt":
                    return "text/plain";
                case ".css":
                    return "text/css";
                case ".js":
                    return "text/javascript";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".pdf":
                    return "application/pdf";
                case ".xml":
                    return "text/xml";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
