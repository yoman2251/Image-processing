using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.UI;

namespace Image
{
    public partial class mainForm : Form
    {        
        private imageProcess _iPObj;
        private imageProcess _iPObj1;
        private Capture _camera = null;
        private List<Button> _imageButtonList = new List<Button>();
        private List<Button> _methodButtonList = new List<Button>();
        private int count = 0;
        private Image<Gray, Single> img_final;
        private Image<Bgr, Byte> temp_frame;
        private bool horizontal_bool = false;
        private bool vertical_bool = false;

        public mainForm()
        {
            InitializeComponent();
            InitializeWebCamera();
            InitalizeUIProperty();           
        }
        //攝影機與影像擷取
        public void InitializeWebCamera()
        {
            _iPObj = new imageProcess();
            _iPObj1 = new imageProcess();
            _camera = new Capture();
            _iPObj.source_frame = _camera.QueryFrame().ToImage<Bgr, Byte>();
            _iPObj.initializeData();
            _iPObj1.source_frame = _camera.QueryFrame().ToImage<Bgr, Byte>();
            _iPObj1.initializeData();

        }
        //button設定
        public void InitalizeUIProperty()
        {
            _imageButtonList.Add(grayButton);
            _imageButtonList.Add(binarizationButton);
            _imageButtonList.Add(negativeButton);
            _imageButtonList.Add(reliefButton);
            _imageButtonList.Add(edgeButton);

            _methodButtonList.Add(horizontalButton);
            _methodButtonList.Add(verticalButton);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                //重複讀取影像
                if ((_iPObj.source_frame = _camera.QueryFrame().ToImage<Bgr, Byte>()) == null) return;
                SourcePictureBox.Image = _iPObj.source_frame.ToBitmap();

                if ((_iPObj1.source_frame = _camera.QueryFrame().ToImage<Bgr, Byte>()) == null) return;
                SourcePictureBox.Image = _iPObj1.source_frame.ToBitmap();

                //***依據被被點擊按鈕，觸發進行影像處理***    
                if (!grayButton.Enabled) _iPObj.gray();
                if (!binarizationButton.Enabled) _iPObj.binarization();
                if (!reliefButton.Enabled) _iPObj.relief();
                if (!negativeButton.Enabled) _iPObj.negative();
                if (!edgeButton.Enabled) _iPObj.edge();

                updateSource();
                updateOutput();
                updateSmoothed();
                updateFaceDection();
            }
        }

        public void updateSource()
        {
            temp_frame = _iPObj.source_frame;
            SourcePictureBox.Image = temp_frame.ToBitmap();
            if (horizontal_bool)
            {
                _iPObj1.horizontal(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                SourcePictureBox.Image = _iPObj1.flip_frame.ToBitmap();
            }
            if (vertical_bool)
            {
                _iPObj1.vertical(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                SourcePictureBox.Image = _iPObj1.flip_frame.ToBitmap();
            }
        }
            public void updateOutput()
        {
            // _iPObj.edge();

            temp_frame = _iPObj.result_frame;
            OutputPictureBox.Image = temp_frame.ToBitmap();
          /*  img_final = _iPObj.grayframe.Sobel(0, 1, 3).Add(_iPObj.grayframe.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0)); 
            OutputPictureBox.Image = img_final.ToBitmap();*/
            if (horizontal_bool)
            {
                _iPObj1.horizontal(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                OutputPictureBox.Image = _iPObj1.flip_frame.ToBitmap();
            }
            if (vertical_bool)
            {
                _iPObj1.vertical(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                OutputPictureBox.Image = _iPObj1.flip_frame.ToBitmap();

            }
        }

        public void updateSmoothed()
        {
            _iPObj.smoothed();
            temp_frame = _iPObj.grayframe.Convert<Bgr, byte>();
            smoothedBox.Image = temp_frame.ToBitmap();
            if (horizontal_bool)
              {
                  _iPObj1.horizontal(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                  smoothedBox.Image = _iPObj1.flip_frame.ToBitmap();
              }
              if (vertical_bool)
              {
                  _iPObj1.vertical(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                smoothedBox.Image = _iPObj1.flip_frame.ToBitmap();

              }

        }

        public void updateFaceDection()
        {
            _iPObj.facedetect();
            temp_frame = _iPObj.facedetect_frame;
            //faceDetectionBox.Image = _iPObj.facedetect_frame.ToBitmap();
            faceDetectionBox.Image = temp_frame.ToBitmap();
            if (horizontal_bool)
            {
                _iPObj1.horizontal(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                faceDetectionBox.Image = _iPObj1.flip_frame.ToBitmap();
            }
            if (vertical_bool)
            {
                _iPObj.vertical(temp_frame);
                temp_frame = _iPObj1.flip_frame;
                faceDetectionBox.Image = _iPObj.flip_frame.ToBitmap();
            }
        }

        //按鈕狀態控制
        private void enableControll(Button clickedButton)
        {
            //被點擊按鈕Enabled = false，並在timer_Tick中觸發該功能
            foreach (Button b in _imageButtonList) b.Enabled = true;            
            if(clickedButton != null) clickedButton.Enabled = false;

        }
        private void disableControll(Button clickedButton)
        {
            foreach (Button b in _imageButtonList) b.Enabled = false;
        }

        //開啟攝影機
        private void liveButton_Click(object sender, EventArgs e)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        {
            enableControll(null);
            if (count % 2 == 0)
            {
                liveButton.Text = "stop";
                timer.Start();               
                count++;
            }
            else if (count % 2 == 1)
            {
                disableControll(null);
                liveButton.Text = "start";
                timer.Stop();
                SourcePictureBox.Image = null;
                OutputPictureBox.Image = null;
                smoothedBox.Image = null;
                faceDetectionBox.Image = null;
               
                count++;
            }
        }       
        //離開
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
            InitializeComponent();
        }

        //水平翻轉
        private void horizontal_Click(object sender, EventArgs e)
        {
            //enableControll((Button)sender);
            if (!horizontal_bool) horizontal_bool = true;
            else horizontal_bool = false;
        }

        //垂直翻轉
        private void verticalButton_Click(object sender, EventArgs e)
        {
            // enableControll((Button)sender);
            if (!vertical_bool) vertical_bool = true;
            else vertical_bool = false;
        }

        //灰階
        private void grayButton_Click(object sender, EventArgs e)
        {
            enableControll((Button)sender);          
        }      
        //二值化
        private void binarizationButton_Click(object sender, EventArgs e)
        {  
             enableControll((Button)sender);
        }
        //負片
        private void negativeButton_Click(object sender, EventArgs e)
        {
             enableControll((Button)sender);
        }
        //浮雕
        private void reliefButton_Click(object sender, EventArgs e)
        {
            enableControll((Button)sender);
        }

        private void SourcePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //此為滑鼠按下事件，紀錄追蹤物件的左上角座標          
        }
        private void SourcePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //此為滑鼠放開事件，紀錄追蹤物件的右下角座標
            //用於框選輸入影像中，欲追蹤之顏色物件

            //座標擷取方法與比例轉換，可參考作業1之去背功能中的像素選擇
        }

        private void edgeButton_Click(object sender, EventArgs e)
        {
            enableControll((Button)sender);
        }
    }
}
