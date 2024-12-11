using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    public int CornerRadius { get; set; } = 20; // Default radius

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Parent.BackColor);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90); // Top-left
            path.AddArc(new Rectangle(Width - CornerRadius, 0, CornerRadius, CornerRadius), 270, 90); // Top-right
            path.AddArc(new Rectangle(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius), 0, 90); // Bottom-right
            path.AddArc(new Rectangle(0, Height - CornerRadius, CornerRadius, CornerRadius), 90, 90); // Bottom-left
            path.CloseAllFigures();

            // Fill the panel
            using (Brush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Optional: Draw border
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

    public Color BorderColor { get; set; } = Color.Black; // Default border color
    public float BorderWidth { get; set; } = 2; // Default border width
}
