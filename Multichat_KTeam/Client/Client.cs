using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

namespace Multichat_KTeam
{
    public partial class Client : Form
    {
        IPEndPoint IP;
        Socket client;

        public Client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Connect();
        }

        /// <summary>
        /// Kết nối đến server
        /// </summary>
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2010);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server", "Lỗi");
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// Đóng kết nối socket
        /// </summary>
        
        void CloseConnection()
        {
            client.Close();
        }

        /// <summary>
        /// Gửi tin nhắn đến server
        /// </summary>
        void Send()
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {
                ServerResponse response = new ServerResponse()
                {
                    Type = ServerResponseType.SendString,
                    Data = txtInput.Text
                };

                client.Send(Serialize(response));
            }
        }

        /// <summary>
        /// Lắng nghe phản hồi từ phía server
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 5000];
                    client.Receive(buffer);

                    ServerResponse response = (ServerResponse)Deserialize(buffer);

                    switch (response.Type)
                    {
                        case ServerResponseType.SendString:
                            AddMessage("Server: " + (string)response.Data);
                            break;

                        case ServerResponseType.SendStudentList:
                            break;
                        case ServerResponseType.SendBitmap:
                            Bitmap bitmap = response.Data as Bitmap;
                            string imageName = "image_" + new Random().Next(1000, 9000) + ".jpeg";
                            bitmap.Save(imageName, ImageFormat.Jpeg);

                            AddMessage("Receive image, save as: " + imageName);
                            break;
                        default:
                            break;
                    }
                }
            } 
            catch {
                MessageBox.Show("Có lỗi xảy ra trong quá trình nhận phản hồi từ server. Đóng kết nối");
                CloseConnection();
            }
        }


        /// <summary>
        /// Thêm tin nhắn vào màn hình
        /// </summary>
        /// <param name="message"></param>
        void AddMessage(string message)
        {
            lsvMain.Items.Add(new ListViewItem() { Text = message });
        }

        /// <summary>
        /// Phân mảnh dữ liệu, tạo thành mảng byte để gửi đi
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Serialize(object data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);

            return stream.ToArray();
        }

        /// <summary>
        /// Gom mảnh dữ liệu, tạo thành đối tượng ban đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        /// <summary>
        /// Đóng kết nối khi đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        /// <summary>
        /// Gửi tin nhắn đến server khi bấm vào nút Send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(txtInput.Text);
            txtInput.Text = "";
        }

        private void btnSendDocx_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Word Files(*.Doc;*.Docx;)|*.DOC;*.DOCX;|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Open Word document using FileStream.
                FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open);

                // Copy file stream to MemoryStream.
                MemoryStream memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);

                // Gets byte array from memory stream of file.
                byte[] temp = memoryStream.ToArray();

                ServerResponse response = new ServerResponse()
                {
                    Type = ServerResponseType.SendDocx,
                    Data = temp
                };

                client.Send(Serialize(response));
                AddMessage("Send Word File: " + dialog.FileName);
            }
        }
    }
}
