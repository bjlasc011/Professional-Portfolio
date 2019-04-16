using Emgu.CV;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAnalysis
{
    public partial class VectorView : Form
    {
        Mat src;
        VectorOfVectorOfPoint eigenValues;
        VectorOfVectorOfPoint eigenVectors;

        public VectorView(Mat _src, VectorOfVectorOfPoint _eigenValues, VectorOfVectorOfPoint _eigenVectors)
        {
            src = _src;
            eigenValues = _eigenValues;
            eigenVectors = _eigenVectors;
            InitializeComponent();
        }

        private void VectorView_Load(object sender, EventArgs e)
        {
            GetScaledImages(src, out eigenValues, out eigenVectors);
        }

        private void GetScaledImages(Mat src, out VectorOfVectorOfPoint eigenValues, out VectorOfVectorOfPoint eigenVectors)
        {
            int blockW = 16;
            int blockH = 16;
            Size blockSize = new Size(blockW, blockH);
            int w = src.Width / 16;
            int h = src.Height / 16;
            VectorOfVectorOfPoint vecs = new VectorOfVectorOfPoint();
            for(int i = 0; i < w; ++i)
            {
                for(int j = 0; j < h; ++j)
                {
                    using (Mat cur = new Mat(src, new Rectangle(new Point(i, j), blockSize)))
                    {
                        VectorOfPoint eigVal = new VectorOfPoint();
                        VectorOfPoint eigVec = new VectorOfPoint();
                        CvInvoke.SVDecomp(cur, eigVal, eigVec, new Mat(), Emgu.CV.CvEnum.SvdFlag.Default);
                    }
                }
            }
            eigenValues = new VectorOfVectorOfPoint();
            eigenVectors = new VectorOfVectorOfPoint();
            CvInvoke.SVDecomp(src, eigenValues, eigenVectors, new Mat(), Emgu.CV.CvEnum.SvdFlag.ModifyA);
        }
    }
}
