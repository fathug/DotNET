using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ComModule
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private bool serverRunning = false; // 判断服务器是否运行

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // 获取端口号
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("请输入有效的端口号！");
                return;
            }

            // 启动服务器
            serverRunning = true;
            serverThread = new Thread(() => StartServer(port));
            serverThread.IsBackground = true;
            serverThread.Start();
            btnStartServer.Enabled = false; // 禁用按钮以防止重复启动
            btnStopServer.Enabled = true;
        }

        private void StartServer(int port)
        {
            try
            {
                // 创建TCP监听器
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                UpdateReceivedData("服务器已启动，等待客户端连接...");

                while (serverRunning) // 检查服务器是否要继续运行
                {
                    if(server.Pending())
                    {
                        // 等待客户端连接
                        TcpClient client = server.AcceptTcpClient();
                        UpdateReceivedData("客户端已连接！");

                        // 处理客户端连接
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // 接收数据
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            UpdateReceivedData($"收到数据: {dataReceived}");

                            // 处理接收到的命令
                            ProcessCommand(dataReceived, stream);
                        }

                        // 关闭客户端连接
                        client.Close();
                        UpdateReceivedData("客户端已断开连接！");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateReceivedData($"服务器错误: {ex.Message}");
            }
            finally
            {
                if( server != null)
                {
                    server.Stop();
                }
                UpdateReceivedData("服务器已停止");
            }
        }

        // 更新接收的数据到UI线程
        private void UpdateReceivedData(string message)
        {
            if (txtReceivedData.InvokeRequired)
            {
                txtReceivedData.Invoke(new Action(() => txtReceivedData.AppendText(message + Environment.NewLine)));
            }
            else
            {
                txtReceivedData.AppendText(message + Environment.NewLine);
            }
        }

        // 处理命令的方法
        private void ProcessCommand(string jsonData, NetworkStream stream)
        {
            try
            {
                // 解析JSON数据
                dynamic TcpRequest = JsonConvert.DeserializeObject(jsonData);

                if (TcpRequest != null && TcpRequest.command != null)
                {
                    string commandName = TcpRequest.command.ToString(); //获取JSON串中command字段

                    switch (commandName)
                    {
                        case "Command1":
                            Task1(stream);
                            break;
                        case "Command2":
                            Task2(stream);
                            break;
                        // 你可以在这里添加更多的命令处理
                        default:
                            UpdateReceivedData($"未知命令: {commandName}");
                            break;
                    }
                }
                else
                {
                    UpdateReceivedData("无法解析命令。");
                }
            }
            catch (Exception ex)
            {
                UpdateReceivedData($"处理命令时出错: {ex.Message}");
            }
        }

        #region 这部分是解析到命令之后，需要执行对应的任务。任务可以写在别的项目文件中
        private void Task1(NetworkStream stream)
        {
            // 检查当前线程是否为创建控件的线程，使用Invoke来确保线程安全的更新UI控件
            if (this.txtCommand.InvokeRequired)
            {
                this.txtCommand.Invoke(new Action(() => this.txtCommand.Text = "Command1"));
            }
            else
            {
                this.txtCommand.Text = "Command1";
            }
            SendResponse(stream, "Command1已响应", "0");
        }

        private void Task2(NetworkStream stream)
        {
            if (this.txtCommand.InvokeRequired)
            {
                this.txtCommand.Invoke(new Action(() => this.txtCommand.Text = "Command2"));
            }
            else
            {
                this.txtCommand.Text = "Command2";
            }
            SendResponse(stream, "Command2已响应", "0");
        }

        #endregion

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            serverRunning = false;  // 停止服务器的运行
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;

            if (server != null)
            {
                server.Stop();  // 停止服务器监听
            }

            UpdateReceivedData("服务器已主动断开。");
        }

        private void SendResponse(NetworkStream stream, string message, string status)
        {
            if (stream != null && stream.CanWrite)
            {
                var responseData = new ResponseData
                {
                    Status = status,
                    Message = message,
                };

                string jsonResponse = JsonConvert.SerializeObject(responseData);
                byte[] responseBytes = Encoding.ASCII.GetBytes(jsonResponse);
                stream.Write(responseBytes, 0, responseBytes.Length);
                UpdateReceivedData($"已发送数据");
            }
        }

        // 发送到客户端的数据体
        public class ResponseData
        {
            // 状态码
            public string Status { get; set; }
            // 数据
            public string Message { get; set; }
        }

    }
}
