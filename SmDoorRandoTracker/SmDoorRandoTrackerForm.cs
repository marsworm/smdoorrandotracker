using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmDoorRandoTracker
{
    public partial class SmDoorRandoTrackerForm : Form
    {
        private readonly Image image;
        private readonly MapInfo mapInfo;
        private bool editmode = false;
        //private readonly List<ColorButton> colorButtons = new List<ColorButton>();
        private Area focusArea;
        private int offx;
        private int offy;
        private readonly List<Door> lastDoorAdded = new List<Door>();
        private readonly List<Button> colorButtons = new List<Button>();

        internal const int imageOff = 6;
        public Color DoorColor { get; private set; }
        Point prevMouse;
        bool dragging;
        public SmDoorRandoTrackerForm()
        {
            InitializeComponent();
            DoorColor = Color.Red;
            image = Bitmap.FromFile("map.png");
            FormClosing += SmDoorRandoTrackerForm_FormClosing;
            mapInfo = JsonSerializer.Deserialize<MapInfo>(File.ReadAllText("mapinfo.json"));

            if (File.Exists("mapinfo.edit.json"))
            {
                mapInfo = JsonSerializer.Deserialize<MapInfo>(File.ReadAllText("mapinfo.edit.json"));
            }
            mapInfo.Init();

            Click += SmDoorRandoTrackerForm_Click;
            MouseDown += SmDoorRandoTrackerForm_MouseDown;
            MouseUp += SmDoorRandoTrackerForm_MouseUp;
            MouseMove += SmDoorRandoTrackerForm_MouseMove;
            MouseLeave += SmDoorRandoTrackerForm_MouseLeave;

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            DoubleBuffered = true;

            InitColorButtons();
            offy = GetToolBarOffset();
            SetKeydowns();
            Focus( crateria.Text);
        }

        private void Focus(string text)
        {
            Focus(mapInfo.Areas.FirstOrDefault(a => a.Name == text));
        }

        private void SmDoorRandoTrackerForm_MouseLeave(object sender, EventArgs e)
        {
            dragging = false;
        }

        private void SmDoorRandoTrackerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                offx += e.X - prevMouse.X;
                offy += e.Y - prevMouse.Y;
                prevMouse = e.Location;
                Debug.WriteLine(offx + " " + e.X + " " + prevMouse.X);
                Invalidate();
            }
        }

        private void SmDoorRandoTrackerForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void SmDoorRandoTrackerForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                prevMouse = e.Location;
                dragging = true;
            }
        }

        private void SetKeydowns()
        {
            KeyDown += SmDoorRandoTrackerForm_KeyDown;
            flowLayoutPanel1.KeyDown += SmDoorRandoTrackerForm_KeyDown;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.KeyDown += SmDoorRandoTrackerForm_KeyDown;
            }
        }

        private void InitColorButtons()
        {
            Color[] temp = new Color[] { Color.Red, Color.Green, Color.Orange };
            AddColorButtons(temp);
            Label l = new Label()
            {
                Text = "Beams:",
                ForeColor = Color.White,
                Size = new Size(58, 29),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            };
            l.TextAlign = ContentAlignment.MiddleCenter;

            flowLayoutPanel1.Controls.Add(l);
            temp = new Color[] { Color.Blue, Color.Purple, Color.LimeGreen, Color.Yellow };
            AddColorButtons(temp);
        }

        private void AddColorButtons(Color[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Button c = new Button
                {
                    Size = new Size(norfair.Height, norfair.Height),
                    BackColor = temp[i],
                    FlatStyle = FlatStyle.Flat
                };
                colorButtons.Add(c);
                c.Click += ColorButton_Click;
                flowLayoutPanel1.Controls.Add(c);
            }
        }

        private void Focus(Area area)
        {
            if (area == null)
            {
                return;
            }
            focusArea = area;
            offx = -focusArea.Rect[0].X;
            offy = -focusArea.Rect[0].Y + GetToolBarOffset();
        }

        private int GetToolBarOffset()
        {
            return flowLayoutPanel1.Height + 1;
        }

        private void SmDoorRandoTrackerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                string text = JsonSerializer.Serialize(mapInfo); ;
                File.WriteAllText("mapinfo.edit.json", text);

            }
            else if (e.KeyCode == Keys.C)
            {
                ConnectDoors();
            }
            else if (e.KeyCode == Keys.D1)
            {
                Focus(crateria.Text);
            }
            else if (e.KeyCode == Keys.D2)
            {
                Focus(brinstar.Text);
            }
            else if (e.KeyCode == Keys.D3)
            {
                Focus(wrecked.Text);
            }
            else if (e.KeyCode == Keys.D4)
            {
                Focus(maridia.Text);
            }
            else if (e.KeyCode == Keys.D5)
            {
                Focus(norfair.Text);
            }
            else if (e.KeyCode == Keys.F1)
            {
                editmode = !editmode;

            }
            else if (editmode && e.KeyCode == Keys.Decimal)
            {
                mapInfo.Areas.ForEach(a =>
                {
                    List<Item> selected = a.Items.Where(i => i.DisplayMode == ItemMode.CHECKED).ToList();
                    selected.ForEach(d => a.Items.Remove(d));
                });
            }
            else if (e.KeyCode == Keys.Z && lastDoorAdded.Count > 0)
            {
                foreach (Area a in mapInfo.Areas)
                {
                    Door item = lastDoorAdded.Last();
                    if (a.Doors.Remove(item))
                    {
                        lastDoorAdded.Remove(item);
                        break;
                    }
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                lastDoorAdded.Clear();
                mapInfo.Areas.ForEach(a => a.Doors.Clear());
                mapInfo.Areas.ForEach(a => a.Items.ForEach(i => i.DisplayMode = ItemMode.UNCHECKED));
            }
            Invalidate();
        }

        private void ConnectDoors()
        {
            if(lastDoorAdded.Count >=2)
            {
                Door last = lastDoorAdded.LastOrDefault();
                Door connector = lastDoorAdded[lastDoorAdded.Count - 2];
                last.Connect = new int[] { connector.X, connector.Y };
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            DoorColor = b.BackColor;

            colorButtons.ForEach(i =>
            {
                i.ForeColor = Color.Black;
            });

            b.ForeColor = Color.White;
        }

        private void SmDoorRandoTrackerForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = e as MouseEventArgs;

            Point offsetPoint = new Point(m.X - offx, m.Y - offy);


            Area area = mapInfo.Areas.FirstOrDefault(i => i.Rect.Any(r => r.Contains(offsetPoint.X, offsetPoint.Y)));
            if (area != null)
            {
                Debug.WriteLine(area.Name);
                //snap mouse to grid
                Item item = area.Items.FirstOrDefault(i => i.Contains(offsetPoint));

                if (item != null && item.Contains(offsetPoint))
                {
                    if (m.Button == MouseButtons.Right)
                    {
                        item.RotateHighlight();
                    }
                    else
                    {
                        item.RotateCheck();

                    }
                }
                else if (m.Button == MouseButtons.Left)
                {
                    Door newDoor = new Door(offsetPoint, DoorColor);
                    Door door = area.Doors.FirstOrDefault(d => d.Contains(newDoor.X + (newDoor.W / 2), newDoor.Y + (newDoor.H / 2)));
                    if (door == null)
                    {
                        area.Doors.Add(newDoor);
                        lastDoorAdded.Add(area.Doors.Last());
                    }
                    else
                    {
                        door.Opened = !door.Opened;
                        Debug.WriteLine("already exists");
                    }
                }
                else if (editmode && m.Button == MouseButtons.Right)
                {
                    area.Items.Add(new Item(offsetPoint));
                }
            }
            Invalidate();
        }

        private void SmDoorRandoTrackerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SmDoorRandoTrackerForm_KeyDown(null, new KeyEventArgs(Keys.S));
            image.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            Graphics g = e.Graphics;

            g.TranslateTransform(offx, offy);
            g.DrawImageUnscaled(image, 0, 0);

            DrawAreas(g);
            //DrawGrid(g);
            g.ResetTransform();

        }

        private void DrawAreas(Graphics g)
        {
            foreach (Area a in mapInfo.Areas)
            {
                foreach (Item item in a.Items)
                {
                    Brush b = Brushes.White;
                    if (item.DisplayMode == ItemMode.CHECKED)
                    {
                        b = Brushes.LimeGreen;
                    }
                    else if (item.DisplayMode == ItemMode.HIGHLIGHTED)
                    {
                        b = Brushes.OrangeRed;
                    }
                    g.FillRectangle(b, item.X, item.Y, item.Width, item.Height);
                }
            }
            foreach (Area a in mapInfo.Areas)
            {
                foreach (Door door in a.Doors)
                {
                    Brush col = door.solidBrush;
                    if (door.Opened)
                    {
                        col = Brushes.White;
                    }
                    g.FillRectangle(col, door.X, door.Y, door.W, door.H);
                }
            }
            foreach (Area a in mapInfo.Areas)
            {
                foreach (Door door in a.Doors)
                {
                    if (door.Connect != null)
                    {
                        using (Pen col = new Pen(door.solidBrush.Color))
                        {
                            g.DrawLine(col, door.X, door.Y, door.Connect[0], door.Connect[1]);
                        }
                    }
                }
            }
        }


        private void DrawGrid(Graphics g)
        {

            Pen gridline = Pens.Gray;

            for (int x = 0; x < image.Width; x += 16)
            {
                g.DrawLine(gridline, x, 0, x, image.Height);
            }

            for (int y = 0; y < image.Height; y += 16)
            {
                g.DrawLine(gridline, 0, y, image.Width, y);
            }
        }

        private void FocusArea_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Focus(mapInfo.Areas.FirstOrDefault(i => i.Name == b.Text));
            Invalidate();
        }

    }
}
