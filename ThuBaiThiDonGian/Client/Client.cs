using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Common;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class Client : Form
    {
        private const int SERVER_PORT = 2010;

        IPEndPoint IP;
        Socket client;

        System.Timers.Timer countdown;
        int counter = 0;

        public Client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            btnFinishExam.Enabled = true;

            countdown = new System.Timers.Timer();
            countdown.Interval = 1000;
            countdown.Elapsed += Countdown_Elapsed;
        }




        /// <summary>
        /// Kết nối đến server
        /// </summary>
        void Connect(string hostname, int port)
        {
            IP = new IPEndPoint(IPAddress.Parse(hostname), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string computerName = System.Environment.MachineName;

            try
            {
                client.Connect(IP);

                this.Text = computerName + " - Kết nối thành công";

                ServerResponse container = new ServerResponse()
                {
                    Type = ServerResponseType.SendString,
                    Data = computerName
                };

                client.Send(Serialize(container));
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
            if (client != null)
                client.Close();
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
                    byte[] buffer = new byte[1024 * 1024 * 20];
                    client.Receive(buffer);

                    object data = Deserialize(buffer);
                    ServerResponse container = data as ServerResponse;

                    switch (container.Type)
                    {
                        case ServerResponseType.SendFile:

                            FileResponse fileResponse = container.Data as FileResponse;

                            string fileName = fileResponse.FileInfo.Name;
                            lblDeThi.Text = fileName;

                            using (var fileStream = File.Create(fileName))
                            {
                                fileStream.Write(fileResponse.FileContent, 0, fileResponse.FileContent.Length);
                            }

                            break;

                        case ServerResponseType.SendList:

                            List<Student> listStudent = container.Data as List<Student>;

                            cbDSThi.DataSource = listStudent;
                            cbDSThi.DisplayMember = "FullNameAndId";

                            break;

                        case ServerResponseType.SendString:
                            break;

                        case ServerResponseType.BeginExam:

                            int minute = (int)container.Data;
                            counter = minute * 60;
                            int hour = minute / 60;

                            lblThoiGian.Text = $"{hour} giờ, {minute % 60} phút";

                            countdown.Enabled = true;

                            break;

                        case ServerResponseType.FinishExam:
                            break;
                        case ServerResponseType.LockClient:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình nhận phản hồi từ server. Đóng kết nối. " + ex.Message);
                CloseConnection();
            }
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

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            string IP = txtServerIP.Text;

            Connect(IP, SERVER_PORT);
        }

        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                Student selectedStudent = cbDSThi.SelectedItem as Student;

                lblHoTen.Text = selectedStudent.FullName;
                lblMaSo.Text = selectedStudent.ID;
            }
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;
            int minute = counter / 60;
            int second = counter % 60;

            lblThoiGianConLai.Text = $"{minute} phút, {second} giây";

            // Kiểm tra nhắc mỗi 30 phút => 30 * 60 = 1800 giây
            if (counter >= 1800 && counter % 1800 == 0)
                MessageBox.Show($"Bạn còn {minute} phút và {second} để làm bài! Nhanh cái chân lên!");

            if (counter == 300)
                MessageBox.Show("Ôi bạn tôi ơi, nhanh lên nào");

            if (counter == 120)
                MessageBox.Show("Ối dồi ôi! Nén bài đi nào bạn tôi ơi");

            if (counter == 0)
            {
                countdown.Stop();
                MessageBox.Show("Đã hết thời gian làm bài. Thu bài");

                // Tìm kiếm trong thư mục hiện tại file .zip
                // Yêu cầu sinh viên nén folder thành file .zip
                // Gửi file zip lên server

                FileResponse file = new FileResponse("1812756_NguyenTrongHieu.zip");

                ServerResponse container = new ServerResponse()
                {
                    Type = ServerResponseType.SendFile,
                    Data = file
                };

                try
                {
                    client.Send(Serialize(container));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    CloseConnection();
                }
            }
        }

        private void btnSendStudentInfo_Click(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                Student student = cbDSThi.SelectedItem as Student;

                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.SendStudent;
                container.Data = student;

                try
                {
                    client.Send(Serialize(container));

                    MessageBox.Show("Thông tin sinh viên đã được ghi nhận");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi trong quá trình gửi thông tin sinh viên lên server");
                    CloseConnection();
                }
            }
        }
    }
}
