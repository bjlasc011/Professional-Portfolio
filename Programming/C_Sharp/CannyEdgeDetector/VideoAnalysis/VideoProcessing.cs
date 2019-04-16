using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Stitching;
using VideoAnalysis;

namespace VideoProcessing
{
    public partial class VideoProcessing : Form
    {
        private int[] steps = new int[13] { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192 };
        private int gauss = 7;
        private int thresh1 = 20;
        private int thresh2 = 25;
        private int binaryMin = 180;
        private int binaryMax = 255;
        private const float hueByteRatio = 256f / 360f;
        private VideoCapture capture;

        private Dictionary<string, Bgr> pallette = new Dictionary<string, Bgr>() { };
        private Gray binMin;
        private Gray binMax;
        private Gray black = new Gray(0);
        private MCvScalar redScalar = new MCvScalar(0, 0, 255);

        private bool isGray;
        private bool isColor;
        private bool isContour;
        private bool isCannyHierarchy = true;
        private bool isHueShapes;
        private bool isLaplacion;
        private bool isSobel;
        private bool isBinary;
        private bool isFeatures;
        private Image<Bgr, byte> imgSrc;
        private Image<Gray, byte> imgGray;
        private Mat model;
        private int imgWidth;
        private int imgHeight;

        private NodeList nodeList = new NodeList();
        private int accumLimit = 4;
        private bool isAccumulating = false;

        public VideoProcessing()
        {
            InitializeComponent();
        }

        public Mat DrawFeatures(Mat frame)
        {
            return FeatureDetect.Draw(model, frame, out _);
        }

        private void StartVideoCapture()
        {
            if (capture == null)
            {
                capture = new VideoCapture(0);
            }
            imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            capture.ImageGrabbed += ImageGrabbed;
            capture.Start();
            fpsLabel.Text = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps).ToString() + " fps";
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartVideoCapture();
        }

        private void ImageGrabbed(object sender, EventArgs e)
        {
            Mat m = new Mat();
            capture.Retrieve(m);
            imgHeight = m.Height;
            imgWidth = m.Width;
            using (Image<Bgr, byte> frame = new Image<Bgr, byte>(m.Bitmap))
            using (Image<Gray, byte> graySmooth = frame.Convert<Gray, byte>().SmoothGaussian(gauss))
            {
                if (isCannyHierarchy)
                {
                    Image<Gray, byte>[] cannies = new Image<Gray, byte>[]
                    {
                            new Image<Gray, byte>(imgWidth, imgHeight),
                            new Image<Gray, byte>(imgWidth, imgHeight),
                            new Image<Gray, byte>(imgWidth, imgHeight),
                            new Image<Gray, byte>(imgWidth, imgHeight),
                            new Image<Gray, byte>(imgWidth, imgHeight)
                    };
                    using (Image<Gray, byte> gray = frame.Convert<Gray, byte>())
                    using (Image<Bgr, byte> temp = new Image<Bgr, byte>(imgWidth, imgHeight))
                    {
                        cannies[0] = gray.SmoothGaussian(gauss).Canny(thresh1, thresh2);
                        cannies[1] = gray.SmoothGaussian(7).Canny(20, 15);
                        cannies[2] = gray.SmoothGaussian(11).Canny(15, 30);
                        cannies[3] = gray.SmoothGaussian(15).Canny(40, 60);
                        if (isAccumulating)
                        {
                            AccumulateFrames(cannies[1], out Image<Gray, byte> accumFrames);
                            cannies[4] = accumFrames.SmoothGaussian(1);
                            temp.SetValue(pallette["green3"], cannies[4]);
                        }
                        else temp.SetValue(pallette["green3"], cannies[1]);
                        temp.SetValue(pallette["green2"], cannies[0]);
                        temp.SetValue(pallette["green1"], cannies[2]);
                        temp.SetValue(pallette["green0"], cannies[3]);
                        imageBox1.Image = temp.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                        return;
                    }
                }
                Image<Gray, byte> canny = new Image<Gray, byte>(imgWidth, imgHeight);
                if (!isHueShapes)
                {
                    canny = graySmooth.Canny(thresh1, thresh2);
                }
                if (isGray)
                {
                    graySmooth.SetValue(black, canny);
                    imageBox1.Image = graySmooth.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                    canny.Dispose();
                    return;
                }
                else if (isColor)
                {
                    using (Image<Bgr, byte> frameOverlay = frame.Clone())
                    {
                        frameOverlay.SetValue(pallette[Color.LawnGreen.Name], canny);
                        imageBox1.Image = frameOverlay.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                        frameOverlay.Dispose();
                        canny.Dispose();
                    }
                    return;
                }
                else if (isContour)
                {
                    Image<Bgr, byte> temp = new Image<Bgr, byte>(imgWidth, imgHeight);
                    GetContours(graySmooth, out temp);
                    imageBox1.Image = temp.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                    temp.Dispose();
                    return;
                }
                else if (isHueShapes)
                {
                    Image<Gray, byte> hueImgGray = new Image<Gray, byte>(imgWidth, imgHeight);
                    using (Image<Bgr, byte> temp = new Image<Bgr, byte>(m.Bitmap))
                    {
                        GetHueGray(temp, out hueImgGray);
                        imageBox1.Image = hueImgGray.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                    }
                    return;
                }
                else if (isLaplacion)
                {
                    using (Image<Gray, byte> gray = frame.Convert<Gray, byte>())
                    using (Image<Gray, float> temp = gray.Laplace(5))
                    {
                        imageBox1.Image = temp.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                    }
                    return;
                }
                else if (isSobel)
                {
                    using (Image<Gray, byte> gray = frame.Convert<Gray, byte>())
                    using (Image<Gray, float> temp = gray.Sobel(1, 1, 5))
                    {
                        imageBox1.Image = temp.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                    }
                    return;
                }
                else if (isBinary)
                {
                    using (Image<Gray, byte> gray = frame.Convert<Gray, byte>())
                    using (Image<Gray, byte> imgGray = new Image<Gray, byte>(imgWidth, imgHeight))
                    {
                        CvInvoke.Threshold(gray, imgGray, binaryMin, binaryMax, Emgu.CV.CvEnum.ThresholdType.Binary);
                        imageBox1.Image = imgGray.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                        return;
                    }
                }
                else if (isFeatures)
                {
                    imageBox1.Image = DrawFeatures(m);
                }
            }
        }

        private void AccumulateFrames(Image<Gray, byte> grayFrame, out Image<Gray, byte> outImg)
        {
            outImg = new Image<Gray, byte>(imgWidth, imgHeight);
            nodeList.PushFront(grayFrame);
            if (nodeList.count == accumLimit)
            {
                nodeList.Pop();
                Node current = nodeList.firstNode;
                while (current.next != null)
                {
                    outImg += current.data;
                    current = current.next;
                }
                outImg += current.data;
            }
            else
            {
                Node current = nodeList.firstNode;
                while (current.next != null)
                {
                    outImg += current.data;
                    current = current.next;
                }
                outImg += current.data;
            }
        }

        private void GetScaledImages(Mat src, out VectorOfVectorOfPoint eigenValues, out VectorOfVectorOfPoint eigenVectors)
        {
            eigenValues = new VectorOfVectorOfPoint();
            eigenVectors = new VectorOfVectorOfPoint();
            CvInvoke.SVDecomp(src, eigenValues, eigenVectors, new Mat(), Emgu.CV.CvEnum.SvdFlag.ModifyA);
        }

        private void GetContours(Image<Gray, byte> grayImg, out Image<Bgr, byte> outImg)
        {

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Image<Bgr, byte> temp = new Image<Bgr, byte>(grayImg.Width, grayImg.Height);
            Image<Gray, byte> binaryGrayImg = grayImg.ThresholdBinary(new Gray(binaryMin), new Gray(binaryMax));
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(
                binaryGrayImg,
                contours,
                hierarchy,
                Emgu.CV.CvEnum.RetrType.List,
                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple
            );
            CvInvoke.DrawContours(temp, contours, -1, redScalar);
            outImg = temp;
        }

        private void SetHistogram(Emgu.CV.UI.HistogramBox histogramBox, Image<Bgr, byte> frame)
        {
            histogramBox.ClearHistogram();
            histogramBox.GenerateHistograms(frame, 255);
            histogramBox.Refresh();
        }

        private void GetHueGray(Image<Bgr, byte> img, out Image<Gray, byte> hueGrayImg)
        {
            hueGrayImg = img.Convert<Gray, byte>();
            Image<Bgr, byte> temp = new Image<Bgr, byte>(img.Bitmap);
            for (int y = 0; y < img.Height; ++y)
            {
                for (int x = 0; x < img.Width; ++x)
                {
                    float hue = GetHue(img, x, y);
                    float ratioHue = (float)Math.Floor(hue * hueByteRatio);
                    hueGrayImg.Data[y, x, 0] = (byte)ratioHue;
                }
            }
        }

        private float GetHue(Image<Bgr, byte> img, int x, int y)
        {
            Color clr = Color.FromArgb(img.Data[y, x, 2], img.Data[y, x, 1], img.Data[y, x, 0]);
            return clr.GetHue();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture != null)
                capture.Stop();
        }

        private void analyzeBttn_Click(object sender, EventArgs e)
        {
            TrySetCannyInputs();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture != null)
                capture.Pause();
        }

        public bool TrySetCannyInputs() {
            if (
                int.TryParse(gaussTxt.Text, out gauss) &&
                int.TryParse(thresh1Txt.Text, out thresh1) &&
                int.TryParse(thresh2Txt.Text, out thresh2) &&
                int.TryParse(binaryMinTxt.Text, out binaryMin) &&
                int.TryParse(binaryMaxTxt.Text, out binaryMax)
            )
            {
                binMin = new Gray(binaryMin); binMax = new Gray(binaryMax);
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartVideoCapture();
            binaryMaxTxt.Text = binaryMax.ToString();
            binaryMinTxt.Text = binaryMin.ToString();
            gaussTxt.Text = gauss.ToString();
            thresh1Txt.Text = thresh1.ToString();
            thresh2Txt.Text = thresh2.ToString();
            InitColorPalette();
        }

        private void InitColorPalette()
        {
            KnownColor[] values = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor kc in values)
            {
                Color clr = Color.FromKnownColor(kc);
                pallette.Add(clr.Name, new Bgr(clr.B, clr.G, clr.R));
            }
            pallette.Add("green0", new Bgr(80, 255, 80));
            pallette.Add("green1", new Bgr(45, 150, 45));
            pallette.Add("green2", new Bgr(10, 80, 10));
            pallette.Add("green3", new Bgr(5, 50, 5));
        }

        private void VideoInputRadioBttn_CheckChanged(object sender, EventArgs e)
        {
            RadioButton chk = sender as RadioButton;
            isColor = (chk.Name == colorRadio.Name && chk.Checked);
            isGray = (chk.Name == grayRadio.Name && chk.Checked);
            isContour = (chk.Name == contourRadio.Name && chk.Checked);
            isCannyHierarchy = (chk.Name == cannyHierarchyRadio.Name && chk.Checked);
            isHueShapes = (chk.Name == hueGrayRadio.Name && chk.Checked);
            isLaplacion = (chk.Name == laplacianRadio.Name && chk.Checked);
            isSobel = (chk.Name == sobelRadio.Name && chk.Checked);
            isBinary = (chk.Name == binaryRadio.Name && chk.Checked);
            isFeatures = (chk.Name == featuresRadio.Name && chk.Checked);
            if(isFeatures && model == null)
            {
                MessageBox.Show("Cannot track image until model is set. Please set Model first.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isAccumulating = checkBox1.Checked;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                this.imgSrc = new Image<Bgr, byte>(open.FileName);
                imageBox1.Image = imgSrc;
            }
        }

        private void hueGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGray = new Image<Gray, byte>(imgSrc.Width, imgSrc.Height);
            imgGray = imgSrc.Convert<Gray, byte>();

            for (int y = 0; y < imgSrc.Height; ++y)
                for (int x = 0; x < imgSrc.Width; ++x)
                {
                    Color clr = Color.FromArgb(imgSrc.Data[y, x, 2], imgSrc.Data[y, x, 1], imgSrc.Data[y, x, 0]);
                    imgGray.Data[y, x, 0] = (byte)(clr.GetHue() * hueByteRatio);
                }
            imageBox1.Image = imgGray;
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGray = imgSrc.Convert<Gray, byte>();
            imageBox1.Image = imgGray.SmoothGaussian(5).Canny(15, 25);
        }

        private void txtBox_Click(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void setModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mat m = new Mat();
            capture.Retrieve(m);
            model = m;
            imageBox2.Image = 
                new Image<Bgr, byte>(model.Bitmap).Resize(imageBox2.Width, imageBox2.Height, Emgu.CV.CvEnum.Inter.Linear);
        }

        private void eigenVectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VectorView eigenForm = new VectorView(imgSrc.Mat, new VectorOfVectorOfPoint(), new VectorOfVectorOfPoint());
            eigenForm.Show();
        }
    }
}
