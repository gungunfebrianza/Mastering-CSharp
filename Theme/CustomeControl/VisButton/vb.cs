using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
 
namespace HackForums.gigajew
{
    /// <summary>
    /// Created by gigajew@hf
    /// </summary>
    public sealed class DescriptiveButton : UserControl
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text { get; set; }
 
        [BrowsableAttribute(true)]
        public Icon Icon { get; set; }
 
        [BrowsableAttribute(true)]
        public Color BackColorHover { get; set; }
 
        [BrowsableAttribute(true)]
        public Color BackColorPressed { get; set; }
 
        [BrowsableAttribute(true)]
        public new int Padding { get; set; }
 
        public DescriptiveButton()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
 
            BackColorHover = SystemColors.ControlLight;
            BackColorPressed = SystemColors.ControlDark;
            Size = new Size(140, 100);
            Padding = 8;
 
            Text = Name;
        }
 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
 
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
 
            Rectangle iconRectangle = new Rectangle(Padding, Padding, 16, 16);
            Rectangle textRectangle = DisplayRectangle;
            textRectangle.X += Padding;
            textRectangle.Width -= Padding * 2;
            textRectangle.Y += Padding;
            textRectangle.Height -= Padding * 2;
 
            if (Icon != null)
            {
                int spacing = iconRectangle.Width + Padding;
                textRectangle.X += spacing;
                textRectangle.Width -= spacing;
 
                e.Graphics.DrawIcon(Icon, iconRectangle);
            }
 
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle, new StringFormat()
            {
                Trimming = StringTrimming.Word,
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });
 
        }
 
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_clicking)
            {
                e.Graphics.Clear(BackColorPressed );
            }
            else if (_hovering)
            {
                e.Graphics.Clear(BackColorHover);
            }
            else {
                base.OnPaintBackground(e);
            }
        }
 
        protected override void OnMouseEnter(EventArgs e)
        {
            _hovering = true;
            base.OnMouseEnter(e);
 
            Invalidate();
        }
 
 
        protected override void OnMouseLeave(EventArgs e)
        {
            _hovering = false;
            base.OnMouseLeave(e);
 
            Invalidate();
        }
 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _clicking = true;
            base.OnMouseDown(e);
 
            Invalidate();
        }
 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _clicking = false;
            base.OnMouseUp(e);
 
            Invalidate();
        }
 
        private bool _hovering;
        private bool _clicking;
    }
}
