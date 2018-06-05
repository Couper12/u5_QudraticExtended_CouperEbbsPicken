/*
 * COuper Ebbs-Picken
 * 6/5/2018
 * do some graphing
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u5_QuadraticExtended_CouperEbbsPicken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global variables
        int aValue;
        int bValue;
        int cValue;
        double output1;
        double output2;
        double discriminant;

        public MainWindow()
        {
            InitializeComponent();
            // creates the y-axis
            Line line1 = new Line();
            line1.StrokeThickness = 1;
            line1.Stroke = Brushes.Black;
            line1.X1 = 325;
            line1.X2 = 325;
            line1.Y1 = 50;
            line1.Y2 = 450;

            // creates x-axis
            Line line2 = new Line();
            line2.StrokeThickness = 1;
            line2.Stroke = Brushes.Black;
            line2.X1 = 125;
            line2.X2 = 525;
            line2.Y1 = 250;
            line2.Y2 = 250;

            // adds the axis to canvas
            canvas.Children.Add(line1);
            canvas.Children.Add(line2);

            // creates ticks on the axis
            for (int i = 0; i < 41; i++)
            {
                Rectangle tick1 = new Rectangle();
                tick1.Height = 10;
                tick1.Width = 1;
                tick1.Fill = Brushes.Black;
                canvas.Children.Add(tick1);
                Canvas.SetLeft(tick1, 125 + (i * 10));
                Canvas.SetTop(tick1, 245);

                Rectangle tick2 = new Rectangle();
                tick2.Height = 1;
                tick2.Width = 10;
                tick2.Fill = Brushes.Black;
                canvas.Children.Add(tick2);
                Canvas.SetLeft(tick2, 320);
                Canvas.SetTop(tick2, 50 + i * 10);
            }

        }


        private void btn_run_Click(object sender, RoutedEventArgs e)
        {
            // removes the old graph
            canvas.Children.RemoveRange(89, 6002);
            int.TryParse(txt_AValue.Text, out aValue);
            int.TryParse(txt_BValue.Text, out bValue);
            int.TryParse(txt_CValue.Text, out cValue);
            
            // does part of the equation
            discriminant = ((bValue * bValue) - (4 * aValue * cValue));

            // checks if there are no zeroes
            if (discriminant < 0)
            {
                lbl_Output.Content = ("there are no zeroes");
            }

            // checks if theres 1 zero
            else if (discriminant == 0)
            {
                output1 = (-bValue) / (2 * aValue);
                lbl_Output.Content = (Math.Round(output1, 3)).ToString();
                bigDot(output1);
            }
            
            // two zeroes
            else
            {
                output1 = (-bValue + Math.Sqrt(discriminant)) / (2 * aValue);
                output2 = (-bValue - Math.Sqrt(discriminant)) / (2 * aValue);
                lbl_Output.Content = (Math.Round(output1, 3).ToString() + ", " + Math.Round(output2, 3).ToString());
                bigDot(output1);
                bigDot(output2);
            }

            // draws the graph
            for (int i = -3000; i < 3001; i++)
            {
                drawDot(i);
            }
        }

        // the method to make a small ellipse to make the curve
        public void drawDot(int xValue)
        {
            Ellipse ellipseX = new Ellipse();
            ellipseX.Width = 2;
            ellipseX.Height = 2;
            ellipseX.Fill = Brushes.Black;
            canvas.Children.Add(ellipseX);
            Canvas.SetLeft(ellipseX, (xValue * 0.005) * 10 + 325);
            Canvas.SetTop(ellipseX, (250 - (((xValue * 0.005 * xValue * 0.005) * aValue + xValue * 0.005 * bValue + cValue) * 10)));
        }

        // draws the big dots for the zeroes
        public void bigDot(double yValue)
        {
            Ellipse ellipseY = new Ellipse();
            ellipseY.Width = 10;
            ellipseY.Height = 10;
            ellipseY.Fill = Brushes.Black;
            canvas.Children.Add(ellipseY);
            Canvas.SetLeft(ellipseY, 322 + yValue * 10);
            Canvas.SetTop(ellipseY, 245);
        }
    }
}
