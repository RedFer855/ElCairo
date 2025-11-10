using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class controlBotonesMenuPrincipal : UserControl
    {
        private Color colorNormal = Color.FromArgb(189, 215, 238);
        private Color colorHover = Color.FromArgb(170, 193, 214);
        private Color colorClick = Color.FromArgb(200, 212, 222);

        // bandera para saber si el botón está siendo presionado
        private bool isPressed = false;

        [Category("Apariencia Botón")]
        [Description("Color de fondo cuando el botón está normal.")]
        public Color ColorNormal
        {
            get => colorNormal;
            set
            {
                colorNormal = value;
                this.BackColor = value;
            }
        }

        [Category("Apariencia Botón")]
        [Description("Color de fondo cuando el mouse está encima.")]
        public Color ColorHover
        {
            get => colorHover;
            set => colorHover = value;
        }

        [Category("Apariencia Botón")]
        [Description("Color de fondo cuando se presiona el botón.")]
        public Color ColorClick
        {
            get => colorClick;
            set => colorClick = value;
        }

        [Category("Apariencia Botón")]
        [Description("Texto que se mostrará en el botón.")]
        public string Texto
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        [Category("Apariencia Botón")]
        [Description("Imagen que se mostrará en el botón.")]
        public Image Imagen
        {
            get => pbxIcono.Image;
            set => pbxIcono.Image = value;
        }

        [Category("Apariencia Botón")]
        [Description("Color del texto del botón.")]
        public Color ColorTexto
        {
            get => lblTitulo.ForeColor;
            set => lblTitulo.ForeColor = value;
        }

        public controlBotonesMenuPrincipal()
        {
            InitializeComponent();
            this.BackColor = colorNormal;

            // Conecta los eventos a todos los controles hijos (incluido el propio UserControl)
            ConectarEventosMouse(this);
        }

        private void ConectarEventosMouse(Control c)
        {
            // NO suscribimos OnClick de this a this (evita recursión).
            // Para el resto de controles (hijos) reenviamos su Click hacia OnClick del UserControl.

            // MouseEnter
            c.MouseEnter += (s, e) =>
            {
                // si está presionado mantenemos colorClick, si no mostramos hover
                this.BackColor = isPressed ? colorClick : colorHover;
            };

            // MouseLeave
            c.MouseLeave += (s, e) =>
            {
                // si está presionado mantenemos colorClick, si no volvemos a normal
                this.BackColor = isPressed ? colorClick : colorNormal;
            };

            // MouseDown
            c.MouseDown += (s, e) =>
            {
                // sólo consideramos botón izquierdo como "click"
                if (e is MouseEventArgs me && me.Button == MouseButtons.Left)
                {
                    isPressed = true;
                    this.BackColor = colorClick;
                }
            };

            // MouseUp
            c.MouseUp += (s, e) =>
            {
                if (e is MouseEventArgs me && me.Button == MouseButtons.Left)
                {
                    isPressed = false;
                    // si el cursor está sobre el control mostramos hover, si no normal
                    var pt = this.PointToClient(Cursor.Position);
                    if (this.ClientRectangle.Contains(pt))
                        this.BackColor = colorHover;
                    else
                        this.BackColor = colorNormal;
                }
            };

            // Si el control es distinto a 'this', reenvía su Click para que
            // al hacer click sobre hijos (label, picturebox) se dispare el Click del UserControl.
            if (!object.ReferenceEquals(c, this))
            {
                c.Click += (s, e) => this.OnClick(e);
            }

            // Propaga a todos los controles hijos (recursivo)
            foreach (Control hijo in c.Controls)
            {
                ConectarEventosMouse(hijo);
            }
        }


    }
}
