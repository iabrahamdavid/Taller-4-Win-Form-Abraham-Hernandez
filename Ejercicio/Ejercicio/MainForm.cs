using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EjFormu05
{
	public partial class MainForm : Form
	{
		private Beisbol ball = new Beisbol();

		public MainForm()
		{
			InitializeComponent();

			label12.Visible = false;
			label9.Visible = false;
			label8.Visible = false;
			label7.Visible = false;
			textBox3.Visible = false;
			textBox2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			label3.Visible = false;
			label4.Visible = false;
			label1.Visible = false;
			textBox1.Visible = false;
			Americana.Visible = false;
			Nacional.Visible = false;
			label5.Visible = false;
			label6.Visible = false;
			GanadosCount.Visible = false;
			PerdidosCount.Visible = false;
			Registrar.Visible = false;
			Buscar.Visible = false;
			Actualizar.Visible = false;
			Reiniciar.Visible = false;
			textBox5.Visible = false;
			comboBox1.Visible = false;
			Nombre.Visible = false;
			Ciudad.Visible = false;
			button8.Visible = false;
			button9.Visible = false;

			Buscar.Click += new EventHandler(Buscar_Click);
			// Evento anónimo

			Registrar.Click += new EventHandler(Registrar_Click);
			Actualizar.Click += new EventHandler(Actualizar_Click);
			Reiniciar.Click += delegate
			{
				Buscar.Enabled = true;
				Registrar.Enabled = true;
				Actualizar.Enabled = false;
				Nombre.Text = "";
				Ciudad.Text = "";
				GanadosCount.Text = "";
				PerdidosCount.Text = "";
				Nacional.Checked = false;
				Americana.Checked = false;
				Nombre.Focus();
			};
		}

		private void Buscar_Click(object sender, EventArgs e)
		{
			if (Nombre.Text == "")
			{

				MessageBox.Show("Debe escribir el nombre del equipo", "AVISO");
			}
			else
			{
				String nombre = Nombre.Text;
				if (ball.Buscar(nombre) == true)
				{
					Baseball m = ball.Consultar(nombre);




					Ciudad.Text = m.NombreCiudad;
					GanadosCount.Text = m.JuegosGanados;
					PerdidosCount.Text = m.JuegosPerdidos;
					if (m.Liga == true)
					{
						Nacional.Checked = true;
					}
					else
					{
						Americana.Checked = true;
					}
					Registrar.Enabled = false;
					Actualizar.Enabled = true;

				}
				else
				{
					MessageBox.Show("El Equipo aún no ha sido registrado", "AVISO");
					Nacional.Checked = false;
					Americana.Checked = false;
					Registrar.Enabled = true;
					Actualizar.Enabled = false;
				}
			}
		}

		private void Registrar_Click(object sender, EventArgs e)
		{
			if ((Nombre.Text == "") || (Ciudad.Text == "") || (Americana.Checked = false) || (Nacional.Checked = false) || (GanadosCount.Text == "") || (PerdidosCount.Text == ""))
			{

				MessageBox.Show("Debe rellenar cada caja de texto", "AVISO");
			}
			else
			{
				String nombre = Nombre.Text;
				if (ball.Buscar(nombre) == false)
				{
					Baseball x = new Baseball();
					x.Nombre = Nombre.Text;
					x.NombreCiudad = Ciudad.Text;
					x.Liga = Nacional.Checked;
					x.JuegosPerdidos = PerdidosCount.Text;
					x.JuegosGanados = GanadosCount.Text;
					ball.Registrar(x);
					MessageBox.Show("El equipo fue registrado correctamente", "AVISO");
				}
				else
				{
					MessageBox.Show("El equipo que intentó registrar, previamente ya fue registrado", "AVISO");
				}
			}
		}

		private void Actualizar_Click(object sender, EventArgs e)
		{
			if ((Nombre.Text == "") || (Ciudad.Text == "") || (Americana.Checked = false ) || (Nacional.Checked = false) || (GanadosCount.Text == "") || (PerdidosCount.Text == ""))
			{

				MessageBox.Show("Debe rellenar cada caja de texto", "AVISO");
			}
			else
			{
				Baseball x = new Baseball();
				x.Nombre = Nombre.Text;
				x.NombreCiudad = Ciudad.Text;
				x.Liga = Nacional.Checked;
				x.JuegosPerdidos = PerdidosCount.Text;
				x.JuegosGanados = GanadosCount.Text;

				if (ball.Buscar(x.Nombre) == true)
				{
					ball.Actualizar(x);
					MessageBox.Show("Los datos del Equipo fueron actualizados correctamente", "AVISO");
				}
				else
				{
					MessageBox.Show("El Nombre del Equipo ingresado, está incorrecto o no existe en nuestros datos.", "AVISO");
				}
			}
		}


		private void button3_Click(object sender, EventArgs e)
		{
			if ((comboBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox5.Text == ""))
			{

				MessageBox.Show("Debe rellenar cada caja de texto","AVISO");
			}
			else
			{
				DialogResult r = MessageBox.Show("Está apunto de registrar un equipo, ¿desea continuar?", "AVISO", MessageBoxButtons.YesNo);

				if (r == DialogResult.Yes)
				{
					MessageBox.Show("El equipo fue registrado exitosamente", "AVISO");
				}
				button4.Enabled = true;
			}
		}

        private void button4_Click(object sender, EventArgs e)
        {
			if ((comboBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox5.Text == ""))
			{

				MessageBox.Show("Debe rellenar cada caja de texto", "AVISO");
			}
			else
			{
				DialogResult r = MessageBox.Show("Al presionar al botón de aceptar actualizara los datos del equipo, sin embargo no tendrá acceso a los datos anteriores.", "AVISO", MessageBoxButtons.YesNo);

			if (r == DialogResult.Yes)
			{
				MessageBox.Show("Los datos del equipo fueron exitosamente actualizados", "AVISO");
			}
			}

		}

        private void button2_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Las cajas de textos fueron reiniciadas para que pueda escribir nuevos equipos", "AVISO");
			button4.Enabled = false;

			textBox2.Text = "";
			textBox3.Text = "";
			textBox5.Text = "";
			comboBox1.Items.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
			DialogResult r = MessageBox.Show("¿Desea salir del programa?", "Salida del programa", MessageBoxButtons.OKCancel);

			if (r == DialogResult.OK)
			{
				Application.Exit();
			}
		}

        private void button5_Click(object sender, EventArgs e)
        {
			if (textBox5.Text == "")
			{

				MessageBox.Show("Debe escribir el nombre del equipo", "AVISO");
			}
			else
			{

				DialogResult r = MessageBox.Show("¿El Equipo que intenta buscar ya fue registrado previamente?", "ATENCIÓN", MessageBoxButtons.YesNo);

				if (r == DialogResult.Yes)
				{
					MessageBox.Show("El equipo fue buscado y encontrado con éxito.", "AVISO");
				}

				else
				{
					MessageBox.Show("El equipo debe ser previamente registrado.");
				}

			}
        }

		private void button1_Click(object sender, EventArgs e)
		{
			if ((comboBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox5.Text == ""))
			{

				MessageBox.Show("Debe rellenar cada caja de texto", "AVISO");
			}
			else
			{

				DialogResult r = MessageBox.Show("¿Desea eliminar por completo los datos del equipo ingresado? RECUERDE: Los datos no podrán ser recuperados", "ATENCIÓN", MessageBoxButtons.YesNo);

				if (r == DialogResult.Yes)
				{
					MessageBox.Show("Los datos del equipo fueron eliminados correctamente", "MENSAJE");
					textBox2.Text = "";
					textBox3.Text = "";
					textBox5.Text = "";
					comboBox1.Items.Clear();
				}
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (textBox4.Text == "")
			{
				MessageBox.Show("Debe de ingresar su nombre antes de continuar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Todos los integrantes del IUJO le damos un gran saludo a '" + textBox4.Text + "'.", "¡Saludos!");
			}
		}

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
			label12.Visible = true;
			label9.Visible = true;
			label8.Visible = true;
			label7.Visible = true;
			textBox3.Visible = true;
			textBox2.Visible = true;
			button3.Visible = true;
			button4.Visible = true;
			button5.Visible = true;
			button2.Visible = true;
			button1.Visible = true;
			textBox5.Visible = true;
			comboBox1.Visible = true;
			button6.Visible = false;
			button8.Visible = true;
		}

        private void button7_Click(object sender, EventArgs e)
        {
			label3.Visible = true;
			label4.Visible = true;
			label1.Visible = true;
			textBox1.Visible = true;
			Americana.Visible = true;
			Nacional.Visible = true;
			label5.Visible = true;
			label6.Visible = true;
			GanadosCount.Visible = true;
			PerdidosCount.Visible = true;
			Registrar.Visible = true;
			Buscar.Visible = true;
			Actualizar.Visible = true;
			Reiniciar.Visible = true;
			Nombre.Visible = true;
			Ciudad.Visible = true;
			button7.Visible = false;
			button9.Visible = true;
		}

        private void button8_Click(object sender, EventArgs e)
        {
			label12.Visible = false;
			label9.Visible = false;
			label8.Visible = false;
			label7.Visible = false;
			textBox3.Visible = false;
			textBox2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			textBox5.Visible = false;
			comboBox1.Visible = false;
			button6.Visible = true;
			button8.Visible = false;
		}

        private void button9_Click(object sender, EventArgs e)
        {
			label3.Visible = false;
			label4.Visible = false;
			label1.Visible = false;
			textBox1.Visible = false;
			Americana.Visible = false;
			Nacional.Visible = false;
			label5.Visible = false;
			label6.Visible = false;
			GanadosCount.Visible = false;
			PerdidosCount.Visible = false;
			Registrar.Visible = false;
			Buscar.Visible = false;
			Actualizar.Visible = false;
			Reiniciar.Visible = false;
			Nombre.Visible = false;
			Ciudad.Visible = false;
			button7.Visible = true;
			button9.Visible = false;
		}

        private void GanadosCount_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= 32 && e.KeyChar < 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
				MessageBox.Show("Debe escribir solo números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
            }
        }

        private void PerdidosCount_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= 32 && e.KeyChar < 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
			{
				MessageBox.Show("Debe escribir solo números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
			}
		}

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= 32 && e.KeyChar < 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
			{
				MessageBox.Show("Debe escribir solo números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
			}
		}

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= 32 && e.KeyChar < 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
			{
				MessageBox.Show("Debe escribir solo números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
			}
		}

    }
    }
