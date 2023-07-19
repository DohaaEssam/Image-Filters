using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[,] ImageMatrix;
        string OpenedFilePath;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            labelScore.Text = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, originalPicture);

            }
        }

        private void btnFilterClicked(object sender, EventArgs e)
        {
            labelScore.Text = "";
            if (OpenedFilePath == null)
                return;
            ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
            string Text_Sort = comboBoxAlgorithm.Text;
            string Text = inputMaxSize.Text;
            string Text_Filter = comboBoxFilter.Text;
            string Text_trim = inputTrim.Text;
            if (Text_trim.Length == 0)
                Text_trim = "0";
            int trimValue = int.Parse(Text_trim);

            if (Text_Sort.Length == 0)
                Text_Sort = "0";
            int Sort = Text_Sort[0] - '0';
            if (Text_Filter.Length == 0)
                Text_Filter = "1";
            int Filter = Text_Filter[0] - '0';
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] >= '0' && Text[i] <= '9')
                    continue;
                else
                    return;
            }
            if (Text.Length == 0)
                return;
            int Max_Size = int.Parse(Text);
            int Start = System.Environment.TickCount;
            ImageOperations.selectFilter(ImageMatrix, Max_Size, Sort, Filter, trimValue);
            int End = System.Environment.TickCount;
            ImageOperations.DisplayImage(ImageMatrix, finalPicture);
            double Time = End - Start;
            Time /= 1000;
            labelScore.Text = (Time).ToString();
            labelScore.Text += " sec";

        }

        private void btnZGraph_Click(object sender, EventArgs e)
        {
            int maxGraph = int.Parse(inputGraph.Text);
            int trimValue = int.Parse(inputTrim.Text);
            double[] xValue = new double[maxGraph];
            double[] yAlphaCounting = new double[maxGraph];
            double[] yAlphaSelect = new double[maxGraph];
            double[] yAdaptiveCounting = new double[maxGraph];
            double[] yAdaptiveQuick = new double[maxGraph];
            int startTime, endTime;
            int timeAlphaSelect, timeAlphaCounting;
            int timeAdaptiveCounting, timeAdaptiveQuick;

            int idx = 0;
            for (int i = 3; i < maxGraph; i += 2)
                xValue[idx++] = i;

            //Compare between Alpha Sorts
            for (int i = 0; i< xValue.Length; i++)
            {
                startTime = System.Environment.TickCount;
                ImageOperations.selectFilter(ImageMatrix, maxGraph, 2, 1, trimValue);
                endTime = System.Environment.TickCount;
                yAlphaCounting[i] = (endTime - startTime);
                timeAlphaCounting = endTime - startTime;

                startTime = System.Environment.TickCount;
                ImageOperations.selectFilter(ImageMatrix, maxGraph, 3, 1, trimValue);
                endTime = System.Environment.TickCount;
                yAlphaSelect[i] = (endTime - startTime);
                timeAlphaSelect = endTime - startTime;
            }

            //Compare between Adaptive Sorts
            for (int i = 0; i < xValue.Length; i++)
            {

                startTime = System.Environment.TickCount;
                ImageOperations.selectFilter(ImageMatrix, maxGraph, 2, 2, trimValue);
                endTime = System.Environment.TickCount;
                yAdaptiveCounting[i] = (endTime - startTime);
                timeAdaptiveCounting = endTime - startTime;

                startTime = System.Environment.TickCount;
                ImageOperations.selectFilter(ImageMatrix, maxGraph, 1, 2, trimValue);
                endTime = System.Environment.TickCount;
                yAdaptiveQuick[i] = (endTime - startTime);
                timeAdaptiveQuick = endTime - startTime;
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF_Alpha = new ZGraphForm("Alpha Filter", "Window size", "Time");
            ZGF_Alpha.add_curve("Alpha Counting Sort", xValue, yAlphaCounting, Color.Red);
            ZGF_Alpha.add_curve("Alpha Select K Sort", xValue, yAlphaSelect, Color.Blue);
            ZGF_Alpha.Show();
            ZGraphForm ZGF_Adaptive= new ZGraphForm("Adaptive Filter", "Window size", "Time");
            ZGF_Adaptive.add_curve("Adaptive Counting Sort", xValue, yAdaptiveCounting, Color.Red);
            ZGF_Adaptive.add_curve("Adaptive Quick Sort", xValue, yAdaptiveQuick, Color.Blue);
            ZGF_Adaptive.Show();
        }

        /*
           System.IndexOutOfRangeException
  HResult=0x80131508
  Message=Index was outside the bounds of the array.
  Source=ImageFilters
  StackTrace:
   at ImageFilters.ImageOperations.countingSort(Byte[] arr, Byte max, Byte min)
   at ImageFilters.ImageOperations.alphaTrim(Byte[,] mtx, Int32 idxX, Int32 idxY, Int32 windowMax, Int32 sortType, Int32 trimValue)
   at ImageFilters.ImageOperations.selectFilter(Byte[,] mtx, Int32 maxSize, Int32 sortType, Int32 filterType, Int32 trimValue)
   at ImageFilters.Form1.btnFilterClicked(Object sender, EventArgs e)
   at System.Windows.Forms.Control.OnClick(EventArgs e)
   at System.Windows.Forms.Button.OnClick(EventArgs e)
   at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
   at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.ButtonBase.WndProc(Message& m)
   at System.Windows.Forms.Button.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   at System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   at System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   at ImageFilters.Program.Main()

           */
        
    }
}