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
        private bool serverRunning = false; // �жϷ������Ƿ�����

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // ��ȡ�˿ں�
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("��������Ч�Ķ˿ںţ�");
                return;
            }

            // ����������
            serverRunning = true;
            serverThread = new Thread(() => StartServer(port));
            serverThread.IsBackground = true;
            serverThread.Start();
            btnStartServer.Enabled = false; // ���ð�ť�Է�ֹ�ظ�����
            btnStopServer.Enabled = true;
        }

        private void StartServer(int port)
        {
            try
            {
                // ����TCP������
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                UpdateReceivedData("���������������ȴ��ͻ�������...");

                while (serverRunning) // ���������Ƿ�Ҫ��������
                {
                    if(server.Pending())
                    {
                        // �ȴ��ͻ�������
                        TcpClient client = server.AcceptTcpClient();
                        UpdateReceivedData("�ͻ��������ӣ�");

                        // ����ͻ�������
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // ��������
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            UpdateReceivedData($"�յ�����: {dataReceived}");

                            // ������յ�������
                            ProcessCommand(dataReceived, stream);
                        }

                        // �رտͻ�������
                        client.Close();
                        UpdateReceivedData("�ͻ����ѶϿ����ӣ�");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateReceivedData($"����������: {ex.Message}");
            }
            finally
            {
                if( server != null)
                {
                    server.Stop();
                }
                UpdateReceivedData("��������ֹͣ");
            }
        }

        // ���½��յ����ݵ�UI�߳�
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

        // ��������ķ���
        private void ProcessCommand(string jsonData, NetworkStream stream)
        {
            try
            {
                // ����JSON����
                dynamic TcpRequest = JsonConvert.DeserializeObject(jsonData);

                if (TcpRequest != null && TcpRequest.command != null)
                {
                    string commandName = TcpRequest.command.ToString(); //��ȡJSON����command�ֶ�

                    switch (commandName)
                    {
                        case "Command1":
                            Task1(stream);
                            break;
                        case "Command2":
                            Task2(stream);
                            break;
                        // �������������Ӹ���������
                        default:
                            UpdateReceivedData($"δ֪����: {commandName}");
                            break;
                    }
                }
                else
                {
                    UpdateReceivedData("�޷��������");
                }
            }
            catch (Exception ex)
            {
                UpdateReceivedData($"��������ʱ����: {ex.Message}");
            }
        }

        #region �ⲿ���ǽ���������֮����Ҫִ�ж�Ӧ�������������д�ڱ����Ŀ�ļ���
        private void Task1(NetworkStream stream)
        {
            // ��鵱ǰ�߳��Ƿ�Ϊ�����ؼ����̣߳�ʹ��Invoke��ȷ���̰߳�ȫ�ĸ���UI�ؼ�
            if (this.txtCommand.InvokeRequired)
            {
                this.txtCommand.Invoke(new Action(() => this.txtCommand.Text = "Command1"));
            }
            else
            {
                this.txtCommand.Text = "Command1";
            }
            SendResponse(stream, "Command1����Ӧ", "0");
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
            SendResponse(stream, "Command2����Ӧ", "0");
        }

        #endregion

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            serverRunning = false;  // ֹͣ������������
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;

            if (server != null)
            {
                server.Stop();  // ֹͣ����������
            }

            UpdateReceivedData("�������������Ͽ���");
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
                UpdateReceivedData($"�ѷ�������");
            }
        }

        // ���͵��ͻ��˵�������
        public class ResponseData
        {
            // ״̬��
            public string Status { get; set; }
            // ����
            public string Message { get; set; }
        }

    }
}
