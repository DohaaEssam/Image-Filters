using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageFilters
{
    public class ImageOperations
    {
        /// <summary>
        /// Open an image, convert it to gray scale and load it into 2D array of size (Height x Width)
        /// </summary>
        /// <param name="ImagePath">Image file path</param>
        /// <returns>2D array of gray values</returns>
        public static byte[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);//O(1)
            int Height = original_bm.Height;//O(1)
            int Width = original_bm.Width;//O(1)

            byte[,] Buffer = new byte[Height, Width];//O(1)

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);//O(1)
                int x, y;//O(1)
                int nWidth = 0;//O(1)
                bool Format32 = false;//O(1)
                bool Format24 = false;//O(1)
                bool Format8 = false;//O(1)

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;//O(1)
                    nWidth = Width * 3;//O(1)
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;//O(1)
                    nWidth = Width * 4;//O(1)
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;//O(1)
                    nWidth = Width;//O(1)
                }
                int nOffset = bmd.Stride - nWidth;//O(1)
                byte* p = (byte*)bmd.Scan0;//O(1)
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x] = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x] = (byte)((int)(p[0] + p[1] + p[2]) / 3);
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }

        /// <summary>
        /// Get the height of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Height</returns>
        
        
        ////////////// O(1)
        public static int GetHeight(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);//O(1)
        }

        /// <summary>
        /// Get the width of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Width</returns>
       
        
        /////////////// O(1)
        public static int GetWidth(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);//O(1)
        }

        /// <summary>
        /// Display the given image on the given PictureBox object
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <param name="PicBox">PictureBox object to display the image on it</param>
        public static void DisplayImage(byte[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = p[1] = p[2] = ImageMatrix[i, j];
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }

        //Counting sort algorithm
        
        ///////////////// O(N+K)
        public static byte[] countingSort(byte[] arr, int arrLength, byte max, byte min)
        {
            byte[] count = new byte[max - min + 1];//O(1)
            int z = 0;//O(1)

            // O(N)
            for (int i = 0; i < count.Length; i++) { 
                count[i] = 0;//O(1)
            }

            // O(N+K)
            for (int i = 0; i < arrLength; i++) { 
                count[arr[i] - min]++; 
            }

            //O(1)
            for (int i = min; i <= max; i++)
            {
                //O(1)
                while (count[i - min]-- > 0)
                {
                    arr[z] = (byte)i;//O(1)
                    z++;//O(1)
                }
            }
            return arr;//O(1)
        }

        //Quick sort
        ///////////////// O(N*log(N))
        public static byte[] quickSort(byte[] arr, int low, int high)
        {
            if (low < high)
            {
                int q = partition(arr, low, high);//O(1)
                quickSort(arr, low, q - 1);
                quickSort(arr, q + 1, high);
            }
            return arr;
        }
        
        
        ///////// O(1)
        public static int partition(byte[] arr, int low, int high)
        {
            byte x = arr[high];//O(1)
            byte temp;//O(1)
            int i = low;//O(1)
            ////// O(1)
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= x)
                {
                    temp = arr[j];//O(1)
                    arr[j] = arr[i];//O(1)
                    arr[i++] = temp;//O(1)
                }
            }
            temp = arr[i];//O(1)
            arr[i] = arr[high];//O(1)
            arr[high] = temp;//O(1)
            return i;//O(1)
        }

        //Alpha Trim Filter
        /////////////////// O(N+log(N)+K)
        public static byte alphaTrim(byte[,] mtx, int idxX, int idxY, int windowMax, int sortType, int trimValue)
        {
            byte[] arr;//O(1)
            int[] Dx, Dy;//O(1)

            //Check if windowMax is not even
            ////O(1)
            if (windowMax % 2 != 0)
            {
                arr = new byte[windowMax * windowMax];//O(1)
                Dx = new int[windowMax * windowMax];//O(1)
                Dy = new int[windowMax * windowMax];//O(1)
            }
            else
            {
                arr = new byte[(windowMax + 1) * (windowMax + 1)];//O(1)
                Dx = new int[(windowMax + 1) * (windowMax + 1)];//O(1)
                Dy = new int[(windowMax + 1) * (windowMax + 1)];//O(1)
            }

            // Split mtx into two 1D array
            int idx = 0;//O(1)

            /////////////////////O(log(N)^2)
            for (int _y = -(windowMax / 2); _y <= (windowMax / 2); _y++)//O(log(N))
            {
                for (int _x = -(windowMax / 2); _x <= (windowMax / 2); _x++)//O(log(N))
                {
                    Dx[idx] = _x;//O(1)
                    Dy[idx] = _y;//O(1)
                    idx++;//O(1)
                }
            }

            /// mtx = [{4,5},{10,2},{7,9}]
            /// x = [4,10,7]
            /// y = [5,2,9]
            /// finalX = [4,7,10]
            /// finalY = [2,5,9]
            /// finalMtx = [{4,2}, {7,5}, {10,9}]

            byte zMax, zMin, z;//O(1)
            int arrLength, sum, newY, newX, avgValue = 0;//O(1)
            sum = 0;//O(1)
            zMax = 0;//O(1)
            zMin = 255;//O(1)
            arrLength = 0;//O(1)
            z = mtx[idxY, idxX];//O(1)

            ////////////O(N)
            for (int i = 0; i < windowMax * windowMax; i++)
            {
                newY = idxY + Dy[i];//O(1)
                newX = idxX + Dx[i];//O(1)
                ////////////////O(N)
                if (newX >= 0 && newX < GetWidth(mtx) && newY >= 0 && newY < GetHeight(mtx))
                {
                    arr[arrLength] = mtx[newY, newX];//O(1)
                    if (arr[arrLength] > zMax)
                        zMax = arr[arrLength];//O(1)
                    if (arr[arrLength] < zMin)
                        zMin = arr[arrLength];//O(1)
                    sum += arr[arrLength];//O(1)
                    arrLength++;//O(1)
                }
            }

            //if Counting sort Selected
            //O(N+K)
            if (sortType == 2)
            {
                sum = 0;//O(1)
                arr = countingSort(arr, arrLength, zMax, zMin);//O(N+K)
                byte[] trimmedArr = new byte[arr.Length - (trimValue * 2)];//O(1)

                //remove Trim value then calculate the new sum & avg
                for (int i = trimValue; i < arr.Length - trimValue; i++)
                    trimmedArr[i-trimValue] = arr[i];//O(1)
                for (int i = 0; i < trimmedArr.Length; i++)
                    sum += trimmedArr[i];//O(1)
                avgValue = sum / trimmedArr.Length;//O(1)
            }
            //if Select k value Selected
            //O(1)
            else if (sortType == 3) {
                //remove the largest and smallest element from the array
                //then calculate the sum & avg
                int k = trimValue;
                sum -= arr[k];//O(1)
                sum -= arr[arrLength-k];//O(1)
                arrLength -= 2;//O(1)
                avgValue = sum / arrLength;//O(1)
            }

            return (byte)avgValue;//O(1)        
        }

        //Adaptive Mid Filter
        /////////////////// O(N+log(N)+K)
        public static byte adaptiveMediumFilter(byte[,] mtx, int idxX, int idxY, int windowSize, int windowMax, int sortType)
        {
            byte[] arr = new byte[windowSize * windowSize];//O(1)
            int[] Dx = new int[windowSize * windowSize];//O(1)
            int[] Dy = new int[windowSize * windowSize];//O(1)
            int idx = 0;//O(1)

            // Split mtx into two 1D array
            for (int _y = -(windowSize / 2); _y <= (windowSize / 2); _y++)//O(log(N))
                for (int _x = -(windowSize / 2); _x <= (windowSize / 2); _x++)//O(log(N))
                {
                    Dx[idx] = _x;//O(1)
                    Dy[idx] = _y;//O(1)
                    idx++;
                }
            byte zMax, zMin, zMid, Z;//O(1)
            int A1, A2, B1, B2, arrLength, newY, newX;//O(1)
            zMax = 0;//O(1)
            zMin = 255;//O(1)
            arrLength = 0;//O(1)
            Z = mtx[idxY, idxX];//O(1)

            ///////// O(N)
            for (int i = 0; i < windowSize * windowSize; i++)
            {
                newY = idxY + Dy[i];//O(1)
                newX = idxX + Dx[i];//O(1)
                //O(1)
                if (newX >= 0 && newX < GetWidth(mtx) && newY >= 0 && newY < GetHeight(mtx))
                {
                    arr[arrLength] = mtx[newY, newX];//O(1)
                    if (arr[arrLength] > zMax)//O(1)
                        zMax = arr[arrLength];//O(1)
                    if (arr[arrLength] < zMin)//O(1)
                        zMin = arr[arrLength];//O(1)
                    arrLength++;//O(1)
                }
            }
            
            ///O(N+K)
            //if sortType is quickSort
            if (sortType == 1) arr = quickSort(arr, zMax, zMin);//O(N*log(N))
            //if sortType is countingSort
            else if (sortType == 2) arr = countingSort(arr, arrLength,zMax, zMin);//O(N+K)
            
            zMin = arr[0];//O(1)
            zMid = arr[arrLength / 2];//O(1)
            A1 = zMid - zMin;//O(1)
            A2 = zMax - zMid;//O(1)
            //step 1
            if (A1 > 0 && A2 > 0)
            {
                B1 = Z - zMin;//O(1)
                B2 = zMax - Z;//O(1)
                //O(1)
                if (B1 > 0 && B2 > 0)
                    return Z;//O(1)
                else//O(1)
                { 
                    if (windowSize + 2 < windowMax)
                        return adaptiveMediumFilter(mtx, idxX, idxY, windowSize + 2, windowMax, sortType);//O(1)
                    else//O(1)
                        return zMid;//O(1)
                }
                    
            }
            //step 2
            //O(1)
            else
            {
                return zMid;//O(1)

            }

        }

        //Choose between two main filters
        ///////// O(N^2+N+log(N)+K)
        public static byte[,] selectFilter(byte[,] mtx, int maxSize, int sortType, int filterType, int trimValue)
        {
            byte[,] mtxFinal = mtx;
            for (int y = 0; y < GetHeight(mtx); y++)//O(N)
            {
                for (int x = 0; x < GetWidth(mtx); x++)//O(N)
                {
                    //O(N+log(N)+K)
                    //Alpha Trim filter
                    if (filterType == 1)
                        mtxFinal[y, x] = alphaTrim(mtx, x, y, maxSize, sortType, trimValue);//O(N+log(N)+K)
                    //Adaptive medium filter
                    else
                        mtxFinal[y, x] = adaptiveMediumFilter(mtx, x, y, 3, maxSize, sortType);//O(N+log(N)+K)
                }
            }
            return mtxFinal;//O(1)
        }
    }

    /*
    System.IndexOutOfRangeException
  HResult=0x80131508
  Message=Index was outside the bounds of the array.
  Source=ImageFilters
  StackTrace:
   at ImageFilters.ImageOperations.partition(Byte[] Array, Int32 p, Int32 r)
   at ImageFilters.ImageOperations.quickSort(Byte[] arr, Int32 low, Int32 high)
   at ImageFilters.ImageOperations.adaptiveMediumFilter(Byte[,] ImageMatrix, Int32 x, Int32 y, Int32 W, Int32 Wmax, Int32 Sort)
   at ImageFilters.ImageOperations.selectFilter(Byte[,] mtx, Int32 maxSize, Int32 Sort, Int32 filter, Int32 trim)
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
