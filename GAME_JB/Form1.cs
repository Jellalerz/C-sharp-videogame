using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME_JB
{
    public partial class Form1 : Form
    {
        bool ka = false, ks = false, kd = false, kw = false;

        List<PictureBox> ListaObstaculosAmarillo = new List<PictureBox>();

        Random RnTipoObstaculo = new Random();
        int Velocidad = 10;
        int puntaje;
        int timer2d = 0;


        Image[] bike = new Image[6];

        public Form1()
        {

            //arreglo con imagenes secuenciales de "animacion" para la moto
            
            InitializeComponent();
            bike[0] = GAME_JB.Properties.Resources.moto2;
            bike[1] = GAME_JB.Properties.Resources.moto3;
            bike[2] = GAME_JB.Properties.Resources.moto4;
            bike[3] = GAME_JB.Properties.Resources.moto5;
            bike[4] = GAME_JB.Properties.Resources.moto6;
            bike[5] = GAME_JB.Properties.Resources.moto7;
          
            //distancia uno y dos determinadas por 
            //int DistanciaUbicacionObstaculo = (UbicacionObstaculo == 1) ? distanciaUno : distanciaDos;
            CrearObstaculo(ListaObstaculosAmarillo, this, 10, 110);
        }
      

            

        //movimiento predeterminado del PJ
        private void timer1_Tick(object sender, EventArgs e)
        {
            


            if (ka == true)
            {
                
                carro1.Location = new Point(carro1.Location.X - 10, carro1.Location.Y);

                


            }
            
            if (kd == true)
            {
                
                carro1.Location = new Point(carro1.Location.X + 10, carro1.Location.Y);
   
              }
              
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //marcador de puntaje
            lblp.Text = ":" +puntaje;
            puntaje++;


            //condicion if en caso de que el picturebox sobrepase los limites admitidos
           if(carro1.Location.X >= 205 || carro1.Location.X <= -30){
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();

                MessageBox.Show("YOU CAN'T GO OUTSIDE THE ROAD");

                label1.Text = "You've got" + lblp.Text + "points";
                label1.Visible = true;
                button1.Visible = true;

            }

            // aumentador de velocidad de acuerdo al puntaje
            if(puntaje > 100)
            {
                Velocidad = 15;
            }
          
            // aumentador de velocidad de acuerdo al puntaje
            if (puntaje > 150)
            {
                Velocidad = 20;
            }
          
            // puntaje necesario para ganar el juego y muestra  pantalla de ganador
            if (puntaje == 201)
            {
                timer2.Stop();
                timer1.Stop();
                Form3 ds = new Form3();
                this.Hide();
                
                ds.Show();

            }



            //ciclco para asignar posiconamiento a todos los elementos dentro de la lista
            foreach (PictureBox ImagenCarro in ListaObstaculosAmarillo)
            {
                //posicionamiento y velocidad de los obstaculos
                int MovimientoY;
                MovimientoY = ImagenCarro.Location.Y;
                MovimientoY = MovimientoY + Velocidad;
                ImagenCarro.Location = new Point(ImagenCarro.Location.X, MovimientoY);

            }   //Creacion de obstaculo en coordenadas.
                //siempre y cuando se cumpla la ejecucion de que el count sea mayor que 0.
                //En pocas palabras esta liena se ejecuta despues de ejecutarse en la forma este codigo
                //CrearObstaculo(ListaObstaculosAmarillo, this, 10, 110);
                if(ListaObstaculosAmarillo.Count > 0)
                { 

                      //las cordenadas de Y deben ser proporcionales al del siguiente if para evitar
                      //multiplicacion de objetos. ya que si es menor que el de la siguiente o viceversa
                      //el juego se reiniciara pero seguiran apareciendo elementos. 

                //asimismo se comprueba que cuando count es mayor que 0 nuestro item de la lista haya
                //pasado las coordenadas establecidas
                    if (ListaObstaculosAmarillo[(ListaObstaculosAmarillo.Count) - 1].Location.Y > 550)
                    {

                    //distanica uno y dos generado por la linea de codigo
                    //int DistanciaUbicacionObstaculo = (UbicacionObstaculo == 1) ? distanciaUno : distanciaDos;
                    CrearObstaculo(ListaObstaculosAmarillo,this,10,140);
                    }
               
                }
          

                // Validacion de choque con PJ y eliminacion objetos de la lista
            if (ListaObstaculosAmarillo.Count > 0)
            {
                //ciclo for para obtener los nombres de los obstaculos
                for(int i=0; i < ListaObstaculosAmarillo.Count; i++)
                {


                    //revisar ambas coordenas en caso de futuro cambio para evitar errores.
                    if (ListaObstaculosAmarillo[i].Location.Y > 550)
                    { 
                     
                        //eliminacion de obstaculos de la lista
                        this.Controls.Remove(ListaObstaculosAmarillo[i]);
                        ListaObstaculosAmarillo.Remove(ListaObstaculosAmarillo[i]);

                    }


                    //validacion de choques y reincio de juego
                    if (ListaObstaculosAmarillo[i].Bounds.IntersectsWith(carro1.Bounds))
                    {
                        
                        //eliminacion de objetos de la lista + reinicio en caso de choque. 
                        this.Controls.Remove(ListaObstaculosAmarillo[i]);
                        ListaObstaculosAmarillo.Remove(ListaObstaculosAmarillo[i]);
                        Reiniciar();
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        label1.Text = "You've got" +lblp.Text+ "points";
                        label1.Visible = true;
                        button1.Visible = true;




                        //si los elementos no se quitan de la lista no dejaran de aparecer
                        //otra forma de detener la ejecucion del juego y simular que el PJ 
                        //pierde es deteniendo el timer. como tal seria el este caso timer2.Stop();
                        //uso las 2 para evitar bugs y quitar el ultimo carro que aprece en pantalla.



                    }





                }
            }
            
        }

        //Metodo para reiniciar la velocidad  en caso de choque y reincio manual
        public void Reiniciar()
        {
            
            Velocidad = 10;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
        }



        //timer animacion de la moto
        private void timer3_Tick(object sender, EventArgs e)
        {
           carro1.Image = bike[timer2d];

            if (timer2d == 5)
            {
                timer2d = -1;
            }

            timer2d++;
            
        }


        //boton para mandar llamar a la forma 4 despues de perder
        private void button1_Click(object sender, EventArgs e)
        {

            Form4 xs = new Form4();
            this.Hide();

            xs.Show();
        }



        //creacion de obstaculos (tipos de coches 11/12/13/14).
        public void CrearObstaculo(List<PictureBox> ListaElementos, Form panelJuegoUno, int distanciaUno, int distanciaDos)
        {
            int NumeroCarro = 1;
           
            //Randomizacion de obstaculos del uno al 2 dependiendo de los obstaculos.
            //Genera un numero aleatorio para la obtencion de un obstaculo en relacion a su etiqueta
            int TipoObstaculo = RnTipoObstaculo.Next(1, 7);
            // si tengo un numero 2 se me genera en el eje 120
            //si tengo un numero 1 se me genera en el eje 10 
            int UbicacionObstaculo = RnTipoObstaculo.Next(1, 3);

            //verificacion de carril evaluando si es uno se genera en el carril izquierdo y en el derecho
            //se genera si cae un 2
            int DistanciaUbicacionObstaculo = (UbicacionObstaculo == 1 ) ? distanciaUno : distanciaDos;

            //agregacion y modificacion de propiedades del nuevo obstaculo 
            PictureBox pb = new PictureBox();
            pb.Location = new Point(DistanciaUbicacionObstaculo, 0);
            pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Obstaculo" + NumeroCarro + TipoObstaculo);
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            ListaElementos.Add(pb);
            panelJuegoUno.Controls.Add(pb);
        }






        //movimiento del PJ
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 

            
            if (e.KeyCode == Keys.A)
            {

                ka = true;
            }
           
            if (e.KeyCode == Keys.D)
            {
                
                kd = true;
            }
            
           
        }



        //Movimiento del PJ
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        { 
           
            if (e.KeyCode == Keys.A)
            {
                
                ka = false;
            }
           
            if (e.KeyCode == Keys.D)
            {
               
                kd = false;
            }
           
        }
    }
}
