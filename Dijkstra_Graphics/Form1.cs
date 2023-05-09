using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dijkstra_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int numberOfNodes = 0;

        Pen pen = new Pen(Color.Black);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Graphics gr;
        int marimeCercNod = 25;
        int marimeText = 10;
        int incrementNodNr = 0;
        int incrementNodNr2 = 0;
        int offsetX = 0;
        int offsetY = 0;
        int graphicsQual = 0;
        List<int> xNod = new List<int>();
        List<int> yNod = new List<int>();
        int indexOfNod = 0;
        int tempX = 0;
        int tempY = 0;
        int tempX_1 = 0;
        int tempY_1 = 0;

        void paintNod(int x, int y, int number)
        {
            numberOfNodes++;
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            gr = this.CreateGraphics();
            if (graphicsQual == 2) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            else if (graphicsQual == 1) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Font drawFont = new Font("Arial", marimeText);
            StringFormat drawFormat = new StringFormat();
            gr.DrawString(Convert.ToString(number), drawFont, drawBrush, xNod[indexOfNod] + (marimeCercNod-8)/2 + offsetX, yNod[indexOfNod]+6 + offsetY, drawFormat);
            gr.DrawEllipse(pen, xNod[indexOfNod],yNod[indexOfNod],marimeCercNod,marimeCercNod);
            incrementNodNr++;
            indexOfNod++;
        }

        void paintNod2(int x, int y, int number)
        {
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            gr = this.CreateGraphics();
            if (graphicsQual == 2) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            else if (graphicsQual == 1) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Font drawFont = new Font("Arial", marimeText);
            StringFormat drawFormat = new StringFormat();
            gr.DrawString(Convert.ToString(number), drawFont, drawBrush, x + (marimeCercNod - 8) / 2 + offsetX, y + 6 + offsetY, drawFormat);
            gr.DrawEllipse(pen, x, y, marimeCercNod, marimeCercNod);
            incrementNodNr2++;
        }






        // A utility function to find the 
        // vertex with minimum distance 
        // value, from the set of vertices 
        // not yet included in shortest 
        // path tree 
        static int V = 9;
        int minDistance(int[] dist, bool[] sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        void printSolution(int[] dist, int n, int nod)
        {
            Console.Write("Nod 	 Distanta "
                        + $"de la nodul {nod} \n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        // Funtion that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation 
        void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 

            // sptSet[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] sptSet = new bool[V];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed 
                sptSet[u] = true;

                // Update dist value of the adjacent 
                // vertices of the picked vertex. 
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in 
                    // sptSet, there is an edge from u 
                    // to v, and total weight of path 
                    // from src to v through u is smaller 
                    // than current value of dist[v] 
                    if (!sptSet[v] && graph[u, v] != 0 &&
                        dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            // print the constructed distance array 
            printSolution(dist, V, src);
        }

        // Driver Code 
        public static void m_class(int nod)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            // nod e nodul pentru care se calculeaza
            Form1 cls = new Form1();
            cls.dijkstra(graph, nod);
        }
    



    


    private void button1_Click(object sender, EventArgs e)
        {
            GFG.m_class(Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //animate
            //  paintNod(150,150,incrementNodNr);
            int a = Convert.ToInt32(textBox2.Text);
            int b = Convert.ToInt32(textBox3.Text);
            getNodeXY(a, 1);
            getNodeXY(b, 2);
            drawLine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // addNodLocations();
            textBox1.Text = "1";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //update the graphics quality 
            if (trackBar1.Value == 0) graphicsQual = 0;
            else if (trackBar1.Value == 1) graphicsQual = 1;
            else if (trackBar1.Value >= 2) graphicsQual = 2;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            paintNod2(e.X, e.Y, incrementNodNr2);
            // add the locations to a list or smth to be able to draw a line between them
            xNod.Add(e.X);
            yNod.Add(e.Y);
        }
        private void getNodeXY(int nodNr, int iteration)
        {
           if(iteration == 1)
           {
                tempX = xNod[nodNr];
                tempY = yNod[nodNr];
           }
           else
            { 
                tempX_1 = xNod[nodNr];
                tempY_1 = yNod[nodNr];
           }
        }
        private void drawLine()
        {
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            gr = this.CreateGraphics();
            if (graphicsQual == 2) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            else if (graphicsQual == 1) gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Font drawFont = new Font("Arial", marimeText);
            StringFormat drawFormat = new StringFormat();
            //  gr.DrawString(Convert.ToString(number), drawFont, drawBrush, x + (marimeCercNod - 8) / 2 + offsetX, y + 6 + offsetY, drawFormat); the weight of the link
            Point p1 = new Point(tempX, tempY);
            Point p2 = new Point(tempX_1, tempY_1);
            gr.DrawLine(pen, p1, p2);
            incrementNodNr2++;
        }
    }
}
