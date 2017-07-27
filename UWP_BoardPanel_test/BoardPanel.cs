using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP_BoardPanel_test {
    public class BoardPanel : Panel {
        #region prop ctor
        public BoardPanel() {
            Rows = 5;
            Columns = 4;
        }
        public BoardPanel(int rows, int columns) {
            Rows = rows;
            Columns = columns;
        }
        private int columns;
        public int Columns {
            get { return columns; }
            set { columns = value; }
        }
        private int rows;
        public int Rows {
            get { return rows; }
            set { rows = value; }
        }
        #endregion
        #region ArrangeOverride MeasureOverride
        protected override Size ArrangeOverride(Size finalSize) {
            double w = finalSize.Width;
            double h = finalSize.Height;

            double x = w / Columns;
            double y = h / Rows;
            double maxWH = Math.Min(x, y);
            if (maxWH < 30) {
                x = y = maxWH = 30;
            } else {
                x = y = maxWH;
            }

            for (int i = 0; i < Children.Count; i++) {
                //double tempX = 50 * (i % Columns);
                //double tempY = 50 * (i / Columns);
                //Children[i].Arrange(new Rect(new Point(9, 9), Children[i].DesiredSize));
                double tempX = maxWH * (i % Columns);
                double tempY = maxWH * (i / Columns);
                Children[i].Arrange(new Rect(new Point(tempX, tempY), new Size(maxWH, maxWH)));

            }
            //return new Size(x * Rows, y * Columns);
            return new Size(maxWH * rows, maxWH * Columns);
        }
        protected override Size MeasureOverride(Size availableSize) {
            double w = availableSize.Width;
            double h = availableSize.Height;
            int rows = 0;
            int ro2 = 0;
            Random rnd = new Random();

            foreach (UIElement child in Children) {
                //child.Measure(availableSize);
                rows++;
                if (child is CellControl == true) {
                    child.Measure(new Size(w / Columns, h / Rows));
                    //child.Measure(new Size(20, 20));
                    //(child as CellControl).Content = $"{w / Columns}x{h / Rows}";

                    double w2 = w / Columns;
                    double h2 = h / Rows;
                    double maxWH = Math.Min(w2, h2);
                    if (maxWH < 30) {
                        w2 = h2 = 30;
                    } else {
                        w2 = h2 = maxWH;
                    }
                    (child as CellControl).Width = w2;
                    (child as CellControl).Height = h2;

                   
                    (child as CellControl).SetValue((Img)rnd.Next(-3,9));
                }
                ro2++;
                //child.Measure(new Size(w/Columns, h/Rows));
            }
            //return new Size(Rows * 100 + 10, Columns * 100 + 10);
            return new Size(w, h);
        }
        #endregion
    }
}
