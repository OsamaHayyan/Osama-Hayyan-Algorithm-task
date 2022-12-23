using System;
using System.Windows.Forms;

namespace insirtionSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {

                string StrData = textBox1.Text;
                string[] StrUnSortedArray = StrData.Split(' ');
                int[] UnSortedArray = Array.ConvertAll(StrUnSortedArray, int.Parse);

                //Insertion Sort for numbers <= 30 number.
                if (UnSortedArray.Length <= 30)
                {
                    for (int i = 1; i < UnSortedArray.Length; i++)
                    {
                        int key = UnSortedArray[i];
                        int j = i - 1;

                        while (j >= 0 && UnSortedArray[j] > key)
                        {
                            UnSortedArray[j + 1] = UnSortedArray[j];
                            j--;
                        }
                        UnSortedArray[j + 1] = key;
                    }
                }
                else
                {
                    //Merge sort for numbers > 30 number
                    void merge(int[] arr, int l, int m, int r)
                    {

                        int n1 = m - l + 1;
                        int n2 = r - m;

                        int[] L = new int[n1];
                        int[] R = new int[n2];
                        int i, j;

                        for (i = 0; i < n1; ++i)
                            L[i] = arr[l + i];
                        for (j = 0; j < n2; ++j)
                            R[j] = arr[m + 1 + j];


                        i = 0;
                        j = 0;


                        int k = l;
                        while (i < n1 && j < n2)
                        {
                            if (L[i] <= R[j])
                            {
                                arr[k] = L[i];
                                i++;
                            }
                            else
                            {
                                arr[k] = R[j];
                                j++;
                            }
                            k++;
                        }

                        while (i < n1)
                        {
                            arr[k] = L[i];
                            i++;
                            k++;
                        }

                        // Copy remaining elements
                        // of R[] if any
                        while (j < n2)
                        {
                            arr[k] = R[j];
                            j++;
                            k++;
                        }
                    }
                    void sort(int[] arr, int l, int r)
                    {
                        if (l < r)
                        {
                            int m = l + (r - l) / 2;
                            sort(arr, l, m);
                            sort(arr, m + 1, r);
                            merge(arr, l, m, r);
                        }
                    }
                    sort(UnSortedArray, 0, UnSortedArray.Length - 1);
                }



                lbl_sort.Text = String.Join(",", UnSortedArray);
            }
            catch (FormatException)
            {
                lbl_sort.Text = "Please type numbers in right form";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                btnSort.Enabled = true;
                return;
            }
            btnSort.Enabled = false;

        }
    }
}
