using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Camera;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private IIPCamera _camera;
        private DrawingImageProvider _imageProvider = new DrawingImageProvider();
        private MediaConnector _connector = new MediaConnector();
        private VideoViewerWF _videoViewerWF1;

        public Form1()
        {
            InitializeComponent();
            int noone;
            float nnnn;
            // Create video viewer UI control
            _videoViewerWF1 = new VideoViewerWF();
            _videoViewerWF1.Name = "videoViewerWF1";
            _videoViewerWF1.Size = panel1.Size;
            panel1.Controls.Add(_videoViewerWF1);

            // Bind the camera image to the UI control
            _videoViewerWF1.SetImageProvider(_imageProvider);
        }

        private void combutton1_Click(object sender, EventArgs e)
        {   //输入
            _camera = IPCameraFactory.GetCamera("rtsp://192.168.113.150:554/ufirststream", "root", "pass");
            _connector.Connect(_camera.VideoChannel, _imageProvider);
            _camera.Start();
            _videoViewerWF1.Start();

        }
    }
}
