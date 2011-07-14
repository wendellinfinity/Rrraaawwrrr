using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RaawwrrGrr
{

    public enum Movement
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ZERO
    }

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            Ellipse orb;
            Movement orbDirection = Movement.ZERO;
            orb = new Ellipse();
            orb.Width = 50;
            orb.Height = 50;
            orb.Fill = new SolidColorBrush(Colors.Orange);
            spaceCanvas.Children.Add(orb);
            Canvas.SetTop(orb, 400);
            System.Threading.Timer bullets;
            System.Threading.Timer enemies;
            spaceCanvas.MouseMove += new MouseEventHandler(
                delegate(object sender, MouseEventArgs e)
                {
                    Dispatcher.BeginInvoke(
                    delegate()
                    {
                        Canvas.SetLeft(orb, e.GetPosition(spaceCanvas).X - 25);
                    });
                }
                );
            spaceCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(
                delegate(object sender, MouseButtonEventArgs e)
                {
                    Ellipse bullet;
                    bullet = new Ellipse();
                    bullet.Height = 10;
                    bullet.Width = 10;
                    bullet.Stroke = new SolidColorBrush(Colors.Red);
                    bullet.Fill = new SolidColorBrush(Colors.Red);
                    Canvas.SetLeft(bullet, Canvas.GetLeft(orb) + 25);
                    Canvas.SetTop(bullet, Canvas.GetTop(orb) + 30);
                    spaceCanvas.Children.Add(bullet);
                    spaceCanvas.UpdateLayout();

                });
            bullets = new System.Threading.Timer(new System.Threading.TimerCallback(
            delegate(object state)
            {
                Dispatcher.BeginInvoke(
                delegate()
                {
                    IList<UIElement> remove = new List<UIElement>();
                    foreach (UIElement bullet in spaceCanvas.Children)
                    {
                        if (bullet != orb)
                        {
                            Canvas.SetTop(bullet, Canvas.GetTop(bullet) - 10);
                            if (Canvas.GetTop(bullet) > 500)
                            {
                                remove.Add(bullet);
                            }
                        }
                    }
                    foreach (UIElement oldbullet in remove)
                    {
                        spaceCanvas.Children.Remove(oldbullet);
                    }
                });
            }), null, 0, 50);

            /*
            enemies = new System.Threading.Timer(new System.Threading.TimerCallback(
            delegate(object state)
            {
                Dispatcher.BeginInvoke(
                delegate()
                {
                    IList<UIElement> remove = new List<UIElement>();
                    foreach (UIElement enemy in spaceCanvas.Children)
                    {
                        if (enemy != orb)
                        {
                            Canvas.SetTop(enemy, Canvas.GetTop(enemy) - 10);
                            if (Canvas.GetTop(enemy) > 500)
                            {
                                remove.Add(enemy);
                            }
                        }
                    }
                    foreach (UIElement oldbullet in remove)
                    {
                        spaceCanvas.Children.Remove(oldbullet);
                    }
                });
            }), null, 0, 50);
            */
        }

        protected void Move(UIElement element, Movement direction)
        {
            Dispatcher.BeginInvoke(
            delegate()
            {
                switch (direction)
                {
                    case Movement.UP:
                        Canvas.SetTop(element, Canvas.GetTop(element) - 1);
                        break;
                    case Movement.DOWN:
                        Canvas.SetTop(element, Canvas.GetTop(element) + 1);
                        break;
                    case Movement.LEFT:
                        Canvas.SetLeft(element, Canvas.GetLeft(element) - 1);
                        break;
                    case Movement.RIGHT:
                        Canvas.SetLeft(element, Canvas.GetLeft(element) + 1);
                        break;
                }
            });

        }

    }
}
